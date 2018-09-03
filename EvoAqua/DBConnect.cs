using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Permissions;

namespace EvoAqua
{
    public class DBConnect : IConnect
    {

        private string directory;
        //Adott mappában lévő fájlok elérésének összegyűjtése egy tömbbe
        //Pl.: C:\Zsolt\Szakdolgozat\EntryAndResults\Változás\LSTCONC_jav.TXT
        public string[] filePaths; 


        //private MySqlConnection conn;
        private MySqlConnection conndb;
        private string server;
        private string database;
        private string uid;
        private string password;



        public DBConnect(string dir, string _server, string _uid, string _password, string _dbName)
        {
            directory = dir;
            server = _server;
            uid = _uid;
            password = _password;
            database = _dbName;

            filePaths = Directory.GetFiles(directory, "*.txt");
           
        }

        public void Initialize()
        {
            

            string connectionString2 = "SERVER=" + server + ";"
            + "DATABASE=" + database + ";" 
            + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conndb = new MySqlConnection(connectionString2); 
            

        }

            //DB kapcsolat megnyitása

        public bool OpenConnection()
        {
            try
            {
                conndb.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //DB kapcsolat bezárása
        public bool CloseConnection()
        {
            try
            {
                conndb.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Kezdeti táblák lekreálása
        public void Ini1_Tables()
        {
            if (this.OpenConnection() == true)
            {
                string pre = "";
                string sql = "";
                
                for (int i = 0; i < filePaths.Length; i++)
                {

                    using (StreamReader sr = new StreamReader(filePaths[i],Encoding.UTF8))
                    {
                        pre = "USE " + database  + ";CREATE TABLE IF NOT EXISTS " + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 4)) + "(";

                        
                        string[] oszlopnev = sr.ReadLine().Split(';');


                        int oszlopokszama = oszlopnev.Count();
                        sql = "";
                        for (int j = 0; j < oszlopnev.Length; j++)
                        {
                            sql = sql + (j < oszlopnev.Length - 1 ? oszlopnev[j] + " varchar(255) NULL," : oszlopnev[j] + " varchar(255) NULL)");

                        }


                        MySqlCommand cmdCreateIns = new MySqlCommand(pre + sql, conndb);


                        cmdCreateIns.ExecuteNonQuery();
                    
                    }

                    
                }
                this.CloseConnection();

                

            }
        }


            public void DropAndCreateTable()
            {
                if (this.OpenConnection() == true)
                {
                

                    //MessageBox.Show(direct); 
                
                    string pre = "";
                    string sql = "";
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        //Beolvasás használata minden egyes fájlra
                        //Pl.:@"C:\Zsolt\Szakdolgozat\EntryAndResults\Változás\LSTCONC_jav.TXT"                   
                            StreamReader sr = new StreamReader(filePaths[i],Encoding.UTF8);

                        
                            //Csak a fájlnév kiszedése '.txt' nélkül --- ez lesz a táblanév Pl.LSTCONC_jav --- és ezzel a táblanévvel a már adatbázisban lévő tábla eldobása és újragenerálása
                            pre = "DROP TABLE " + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 4)) + ";" + "CREATE TABLE " + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 4)) + "(";

                            
                            //Tábla mezőneveinek tömbben való eltárolása
                            string[] oszlopnev = sr.ReadLine().Split(';');

                            //CREATE TABLE parancs törzsének string-be gyűjtése --- tehát az mező- nevek,típusok és NULL-ok megírása 
                            int oszlopokszama = oszlopnev.Count();
                            sql = "";
                            for (int j = 0; j < oszlopnev.Length; j++)
                            {
                                sql = sql + (j < oszlopnev.Length - 1 ? oszlopnev[j] + " varchar(255) NULL," : oszlopnev[j] + " varchar(255) NULL)");

                            }

                            //a két részből álló sql parancs összefűzése
                            MySqlCommand cmdDropCreate = new MySqlCommand(pre + sql, conndb);

                            //a parancs végrehajtása a db serverrel
                            cmdDropCreate.ExecuteNonQuery();

                    sr.Close();

                       
                    }                

                    this.CloseConnection();                
                }

            }
        //A meglévő táblákba való adatok beinzertálása a fájlokból
        public void Insert()
        {
           
            if (this.OpenConnection() == true)
            {
                
                string sql2 = "";
                string sql3 = "";
                for (int i = 0; i < filePaths.Length; i++)
                {
                    
                        sql2 = "";
                        sql2 = "TRUNCATE TABLE " + database +"." + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 4).ToLower()) + "; ";
                        sql3 = "LOAD DATA LOCAL INFILE " + "'" + filePaths[i] + "'" + " INTO TABLE " + database + "." + Path.GetFileName(filePaths[i].Substring(0, filePaths[i].Length - 4).ToLower()) + " FIELDS TERMINATED BY ';' IGNORE 1 LINES";

                    //LOAD DATA LOCAL INFILE 'C:/Zsolt/Szakdolgozat/EntryAndResults/Változás/LSTCONC_jav.TXT' INTO TABLE evoAquaOnline.lstconc_jav FIELDS TERMINATED BY ';' IGNORE 1 LINES
                    string query = sql2 + sql3.Replace('\\', '/');
                        MySqlCommand cmdBulkIns = new MySqlCommand(query, conndb);
                        cmdBulkIns.ExecuteNonQuery();
                    
                }
                
                this.CloseConnection();
                
            }

            
        }

        //Results tábla töltése
        public void InsertToResults()
        {
            if (this.OpenConnection() == true && IsThereAnyTimeResults() == 1)
            {
                string sql4 = "INSERT INTO results(event,round,cat,isThereEntry,heat,rank,lane,idStatus,lap,name,birthYear,club,entryTime,coach,membersOfRelay,time) " +
                    "SELECT lstrslt.event, lstrslt.round, lstcat.text, lsttv.sorszam, lstrslt.heat, lstrslt.rank, lstrslt.lane, lstrslt.idStatus, lstrslt.lap, SUBSTRING(lsttv.nev,2,LENGTH(lsttv.nev)-2), SUBSTRING(lsttv.szuletett,2, LENGTH(lsttv.szuletett)-2), SUBSTRING(lsttv.egyesulet,2, LENGTH(lsttv.egyesulet)-2), SUBSTRING(lsttv.nevezesiido,2, LENGTH(lsttv.nevezesiido)-2), SUBSTRING(lsttv.edzo,2, LENGTH(lsttv.edzo)-2),SUBSTRING(lsttv.valtoosszeallitas,2, LENGTH(lsttv.valtoosszeallitas)-3), SUBSTRING(lstrslt.result,2, LENGTH(lstrslt.result)-2) " +
                    "FROM lsttv " +
                    "RIGHT OUTER JOIN lstrslt " +
                    "ON lstrslt.event = lsttv.sorszam AND lstrslt.heat = lsttv.futam AND lstrslt.lane = lsttv.palya " +
                    "LEFT OUTER JOIN lstcat " +
                    "ON lstrslt.event = lstcat.event " +
                    "WHERE " +
                    "CAST(lstrslt.lap AS INT) = (SELECT MAX(cast(R.lap AS int)) FROM lstrslt R WHERE R.Event = lstrslt.Event) " +
                    "ORDER BY " +
                    "CAST(lstrslt.round AS INT), CAST(lstrslt.event AS INT), CAST(lstrslt.heat AS INT), CAST(lstrslt.lap AS INT), lstrslt.result";

                MySqlCommand insToRes = new MySqlCommand(sql4, conndb);
                insToRes.ExecuteNonQuery();
            }
            if(IsThereAnyTimeResults() == 0)
            {
                MessageBox.Show("It doesn't have any file in the selected folder that contains time results!","Message for timer",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            this.CloseConnection();
        }

        public void AlterLstRound()
        {
            if (this.OpenConnection() == true)
            {                
                       string sql5 = "ALTER TABLE lstround CONVERT TO CHARACTER SET utf8 COLLATE utf8_hungarian_ci;" +
                       "UPDATE lstround SET title = REPLACE(title," + "'" + @"""" + "'" + ", ''); ";

                       MySqlCommand altRounds = new MySqlCommand(sql5, conndb);
                       altRounds.ExecuteNonQuery();
                                                
            }
            this.CloseConnection();
        }

        public void UpdateResults()
        {
            if (this.OpenConnection() == true && IsThereAnyTimeResults() == 1)
            {
                string sql6 = "ALTER TABLE results CONVERT TO CHARACTER SET utf8 COLLATE utf8_hungarian_ci; " +
                    "UPDATE results SET time = CASE WHEN idStatus = 64 THEN 'DNS' WHEN idStatus = 128 THEN 'DQS' " +
                    "WHEN idStatus = 256 THEN 'DNF' WHEN idstatus = 0 AND rank= 0 THEN ' - ' ELSE time END, " +
                    "name = CASE WHEN name IS NULL THEN 'n.a.' ELSE name END, " +
                    "birthYear = CASE WHEN birthYear IS NULL AND cat NOT LIKE '%*%' THEN 'n.a.' WHEN cat LIKE '%*%' THEN ' - ' ELSE birthYear END, " +
                    "rank = CASE WHEN idstatus IN('64','128','256') THEN ' - '  WHEN rank = 0 THEN ' - ' ELSE rank END," +
                    "club = CASE WHEN club IS NULL THEN 'n.a.' WHEN club = '' THEN 'n.a.' ELSE club END, " +
                    "coach = CASE WHEN coach IS NULL THEN 'n.a.' WHEN coach = '' THEN 'n.a.' ELSE coach END, " +
                    "membersOfRelay = CASE WHEN membersOfRelay IS NULL AND cat LIKE '%*%' THEN 'n.a' WHEN cat NOT LIKE '%*%' THEN ' - ' ELSE membersOfRelay END, " +
                    "cat = CASE WHEN cat LIKE '%*%' THEN CONCAT_WS(" + @""" """ + "," +@"""4 * """ +", lap/4," + @"""m""" + ",LTRIM(SUBSTRING_INDEX(cat,'-',-1))) " +
                    "ELSE CONCAT_WS(" + @""" """ + ",lap," + @"""m""" + ",LTRIM(SUBSTRING_INDEX(cat,'-',-1))) END, " +
                    "cat = REPLACE(cat,'ferfi','férfi') " +
                    "WHERE event != '999'";

                MySqlCommand updateResults = new MySqlCommand(sql6, conndb);
                updateResults.ExecuteNonQuery();
            }
            this.CloseConnection();
        }


        private int IsThereAnyTimeResults()
        {
            string sql7 = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '" + database + "' AND table_name = 'lstrslt';";
            MySqlCommand checkTimesFileExist = new MySqlCommand(sql7, conndb);
            object existFile = checkTimesFileExist.ExecuteScalar();

            return Convert.ToInt32(existFile);
        }

      
    }
}
