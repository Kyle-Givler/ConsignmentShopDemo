using System;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalConfig.InitializeConnection(GlobalConfig.DatabaseType.MSSQL);
            GlobalConfig.Store = new Store();

            Application.Run(new ConsignmentShop());
        }
    }
}
