using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MB_Stok_Takip_Pro_v1._0
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
            Application.Run(new Giriş());
        }
    }
}
