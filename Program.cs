using CamDo.View;
using CamDo.Models;

namespace CamDo
{
    public static class Program
    {
        public static String server = "", db = "", uid = "", pw = "", authen = "", role = "renter";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (!Config.ConfigFileExists())
            {
                try
                {
                    Config.LoadConfig();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không tìm thấy config", "Tạo file config mới");
                    Application.Run(new frmConfig());
                }
            }
            try
            {
                Config.LoadConfig();
                Application.Run(new frmLogin());
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi config", e.Message);
            }
        }
    }
}