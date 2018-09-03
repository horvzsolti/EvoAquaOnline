using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvoAqua
{
    public class ServerConnect : IConnect
    {

        private MySqlConnection conn;

        private string server;
        private string uid;
        private string password;
        private string dbName;
        private string connectionString;


        public ServerConnect(string _server, string _uid, string _password, string _dbName)
        {
            server = _server;
            uid = _uid;
            password = _password;
            dbName = _dbName;
        }

        //Connection string
        public void Initialize()
        {
            
            connectionString = "SERVER=" + server + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);

        }

        //DB kapcsolat megnyitása
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
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
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //DB kreálása, ha még nem létezne
        public void Ini0_DB()
        {
            if (this.OpenConnection() == true)
            {
                string iniquery = "CREATE DATABASE IF NOT EXISTS " + dbName + ";";

                MySqlCommand cmdCreate = new MySqlCommand(iniquery, conn);

                cmdCreate.ExecuteNonQuery();
            }
            this.CloseConnection();
        }

    }
}
