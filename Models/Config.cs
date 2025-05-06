using CamDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamDo.Models
{
    public static class Config
    {
        private static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
        public static bool ConfigFileExists()
        {
            return File.Exists(path);
        }

        public static void writeToFile(string[] lines)
        {
            try
            {
                File.WriteAllText(path, string.Join(Environment.NewLine, lines));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing config: " + ex.Message);
            }
        }
        public static void LoadConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("Configuration file not found.", configPath);
            }


            string[] lines = File.ReadAllLines(configPath);

            if (lines.Length < 3)
                throw new Exception("Configuration file does not have enough lines.");

            Program.authen = lines[0].Trim().ToLower();
            if (Program.authen == "windows")
            {
                Program.server = lines[1].Trim();
                Program.db = lines[2].Trim();
                Program.uid = "";
                Program.pw = "";
            }
            else if (Program.authen == "server")
            {
                if (lines.Length < 5)
                    throw new Exception("Configuration file missing username or password in 'server' mode.");

                Program.server = lines[1].Trim();
                Program.db = lines[2].Trim();
                Program.uid = lines[3].Trim();
                Program.pw = lines[4].Trim();
            }
            else
            {
                throw new Exception("Invalid mode in config file. Use 'windows' or 'server' as the first line.");
            }
        }
        public static string GetConnectionString()
        {
            if (Program.authen == "windows")
            {
                return $"Data Source={Program.server};Initial Catalog={Program.db};Integrated Security=True;Trust Server Certificate=True";
            }
            else if (Program.authen == "server")
            {
                return $"Data Source={Program.server};Initial Catalog={Program.db};User ID={Program.uid};Password={Program.pw};Trust Server Certificate=True";
            }
            else
            {
                throw new Exception("Invalid authentication mode in config.");
            }
        }
    }
}
