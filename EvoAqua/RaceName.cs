using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvoAqua
{
    public class RaceName
    {
        private string raceName;
        private string dir;

        public RaceName(string _raceName, string _dir)
        {
            raceName = _raceName;
            dir = _dir;
        }

        public void CreatePhpRace()
        {
            string race = "<?php \n \t $raceName = '" + raceName + "'; \n?>";

            if (File.Exists(dir + "/Codes/race.php"))
            {
                File.Delete(dir + "/Codes/race.php");
                File.WriteAllText(dir + "/Codes/race.php", race, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(dir + "/Codes/race.php", race, Encoding.UTF8);
            }
        }
    }
}
