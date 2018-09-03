using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvoAqua
{
    public class CreatePhpConfig
    {
        private string server;
        private string uid;
        private string password;
        private string dbName;
        private string raceName;
        private string dir; 

        public CreatePhpConfig(string _server, string _uid, string _password, string _dbName, string _raceName, string _dir)
        {
            server = _server;
            uid = _uid;
            password = _password;
            dbName = _dbName;
            raceName = _raceName;
            dir = _dir.Replace('\\', '/');
        }

        public void WriteConfigFile()
        {
            string config = "<?php \n \t return [ \n \t\t 'host' => " + "'" + server + "'" + ", \n\t\t 'username' => " + "'" + uid + "'" + ", \n\t\t 'password' => " + "'" + password + "'" + ", \n\t\t 'dbname' => " + "'" + dbName + "'" + ", \n\t\t 'racename' => " + "'" + raceName + "'" + " \n\t ]; \n ?>";

            if (File.Exists(dir + "/Codes/config.php"))
            {
                File.Delete(dir + "/Codes/config.php");
                File.WriteAllText(dir + "/Codes/config.php", config, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(dir + "/Codes/config.php", config, Encoding.UTF8);
            }
        }
    }
}
