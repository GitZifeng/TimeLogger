using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeLogger
{
    internal static class Program
    {
        public static FrmRemind frmRemind = null;
        public static string SettingPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
        public static UiConfig uiConfig = new UiConfig();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
