using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Security.Permissions;

namespace EvoAqua
{
   
    public partial class Form1 : Form
    {
        string server;
        string uname;
        string pw;
        string dbName;
        string raceName;

        FolderBrowserDialog fbrowser = new FolderBrowserDialog();
        ServerConnect serverObject;
        CreatePhpConfig phpconfig;
        DBConnect databaseObject;
        RaceName rName;
        string dir;

        DateTime regi;
        DateTime uj;
        string path;
        string[] filesInPath;
        bool tooglelight = true;

        public Form1()
        {
            InitializeComponent();         

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b_fileWatcher.Text = "OFF";
            b_fileWatcher.BackColor = Color.Red;

            regi = new DateTime(2018, 1, 1, 0, 0, 0);
            uj = new DateTime(2018, 1, 1, 0, 0, 0);

            timer_fileWatcher.Tick += new EventHandler(CheckChange);
            timer_fileWatcher.Interval = 10000;

        }

        //Megfigyelt mappa beállítása 
        //PHP Config fájl létrehozása
        //Import gomb aktiválása
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbrowser = new FolderBrowserDialog();
            if (fbrowser.ShowDialog() == DialogResult.OK)
            {
                path = fbrowser.SelectedPath;
                tb_watchedDir.Text = path;
                dir = tb_watchedDir.Text;
            }
            else
            {
                return;
            }


            phpconfig = new CreatePhpConfig(server, uname, pw, dbName, raceName, dir);
            phpconfig.WriteConfigFile();

            rName = new RaceName(raceName, dir);
            rName.CreatePhpRace();

            b_imp.Enabled = true;

        }
        
        //kezdődhet az importálás az adatbázisba
        
        private void b_imp_Click(object sender, EventArgs e)
        {           
            databaseObject = new DBConnect(dir,server,uname,pw,dbName);

            databaseObject.Initialize();
            databaseObject.Ini1_Tables();
            databaseObject.Insert();
            databaseObject.InsertToResults();
            databaseObject.AlterLstRound();
            databaseObject.UpdateResults();
                       
            b_fileWatcher.Enabled = true;
        }

        //Meg volt az importálás. El lehet indítani a fájlfigyelőt
        private void b_fileWatcher_Click(object sender, EventArgs e)
        {

            if (tooglelight)
            {
                b_fileWatcher.BackColor = Color.LightGreen;
                b_fileWatcher.Text = "ON";
                tooglelight = false;               
                timer_fileWatcher.Start();
            }
            else
            {
                b_fileWatcher.BackColor = Color.Red;
                b_fileWatcher.Text = "OFF";
                tooglelight = true;
                timer_fileWatcher.Stop();
            }
        }

        //Volt e változás vagy sem. 10 másodpercenként ellenőrizve van.
        private void CheckChange(object sender, EventArgs e)
        {
            filesInPath = Directory.GetFiles(path, "*.txt");
            
            for (int i = 0; i < filesInPath.Length; i++)
            {
                if (File.GetLastWriteTime(Path.Combine(path, filesInPath[i])) > uj)
                {
                    uj = File.GetLastWriteTime(Path.Combine(path, filesInPath[i]));
                }
            }

            if (regi.ToString() == uj.ToString())
            {
                //MessageBox.Show("Nem történt változás!");
                return;
                
               
            }
            else
            {
                //MessageBox.Show("A fájlt felülírták. A legfrisebb felülírás ideje: " + uj);
                tb_lastUpdate.Text = uj.ToString();
                databaseObject.DropAndCreateTable();
                databaseObject.Insert();
                databaseObject.InsertToResults();
                databaseObject.AlterLstRound();
                databaseObject.UpdateResults();
            }

            regi = uj;
        }

        //C# kapcsolódása az adatbázis szerverhez        
        private void b_conf_Click(object sender, EventArgs e)
        {
            server = tb_server.Text;
            uname = tb_uname.Text;
            pw = tb_pw.Text;
            dbName = tb_dbName.Text;
            raceName = tb_raceName.Text;

            serverObject = new ServerConnect(server, uname, pw, dbName);
            serverObject.Initialize();

            // ha nem jött létre a kapcsolat a szerverrel
            if (serverObject.OpenConnection() == false)
            {
                return;
            }

            //ha létrejött a kapcsolat a szerverrel
            else
            {
                if (dbName == "")
                {
                    MessageBox.Show("Database name can not be empty!", "Message for timer");
                    // bezárjuk a kapcsolatot - nehogy a már megnyitottra próbáljunk meg mégegyszer nyitni
                    serverObject.CloseConnection();
                }

                else
                {
                    // bezárjuk a kapcsolatot - nehogy a már megnyitottra próbáljunk meg mégegyszer nyitni
                    serverObject.CloseConnection();
                    serverObject.Ini0_DB();
                    MessageBox.Show("Database " + dbName + " created succesfully. Race name - " + raceName + " - is stored!", "Message for timer");
                    button1.Enabled = true;
                }
                                             
            }

            
            
        }

     
    }
}
