using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class FrmMain : Form
    {
        public static List<AppInfo> appList = new List<AppInfo>();
        private System.Timers.Timer timerUpdateUI = new System.Timers.Timer(1000);
        private ConfigJsonSetting jsonConfig = new ConfigJsonSetting(Program.SettingPath);
        Thread checkAppUseTime = null;
        public int runTime = 0;
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        #region Init
        void Init()
        {
            InitReadConfig();
            dgv.DataGridViewDoubleBuffered();
            checkAppUseTime = new Thread(CheckAppUseTime);
            checkAppUseTime.IsBackground = true;
            checkAppUseTime.Start();
        }
        void InitReadConfig()
        {
            Program.uiConfig = jsonConfig.ReadSetting<UiConfig>() ?? new UiConfig();
            this.cbRemind.Checked = Program.uiConfig.Remind;
            this.cbStartUp.Checked = Program.uiConfig.StartUp;
        }
        void InitWriteConfig()
        {
            Program.uiConfig.Remind = this.cbRemind.Checked;
            Program.uiConfig.StartUp = this.cbStartUp.Checked;
            jsonConfig.WriteSetting(Program.uiConfig);
        }

        #endregion
        private void CheckAppUseTime()
        {
            while (true)
            {
                Thread.Sleep(980);
                UpdateDgv();
                if (runTime == 0)
                    runTime = DateTime.Now.ToUnixTimeStamp();
                if(runTime.OutTimeCheck(20*60))
                {
                    if (Program.frmRemind == null)
                        Program.frmRemind = new FrmRemind();
                    Program.frmRemind.ShowDialog();
                    runTime = 0;    
                }
                if (appList.Count == 0)
                {
                    appList.Add(
                        new AppInfo()
                        {
                            AppTitle = SystemApi.GetActiveAppName(),
                            UseDuration = +1,
                            AppICO = Icon.ExtractAssociatedIcon(SystemApi.GetProcessPath(SystemApi.GetForegroundWindow())).ToBitmap()
                        });
                    continue;
                }
                if(appList.Count>1)
                    appList=appList.OrderByDescending(x => x.UseDuration).ToList();
                List<string> apps = new List<string>();
                foreach (var app in appList)
                {
                    apps.Add(app.AppTitle);
                }
                string appName = SystemApi.GetActiveAppName();
                if (apps.Contains(appName))
                {
                    var locApp = appList.Find(w => w.AppTitle == appName);
                    locApp.UseDuration += 1;
                    locApp.UseDurationTime = sec_to_hms(locApp.UseDuration);
                }
                else
                {
                    //appList.Add(new AppInfo() { AppName = SystemApi.GetActiveAppName(), UseDuration = +1 });
                    appList.Add(
                    new AppInfo()
                    {
                        AppTitle = SystemApi.GetActiveAppName(),
                        UseDuration = +1,
                        AppICO = Icon.ExtractAssociatedIcon(SystemApi.GetProcessPath(SystemApi.GetForegroundWindow())).ToBitmap()
                    });
                }
            }
        }
        private string sec_to_hms(long duration)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
            string str = "";
            if (ts.Hours > 0)
            {
                str = String.Format("{0:00}", ts.Hours) + ":" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = "00:" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = "00:00:" + String.Format("{0:00}", ts.Seconds);
            }
            return str;
        }
        public void UpdateDgv()
        {
            try
            {
                this.Invoke(new EventHandler(delegate
                {
                    dgv.Update(appList);
                }));
            }
            catch
            {

            }

            //Application.DoEvents();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void cbRemind_CheckedChanged(object sender, EventArgs e)
        {
            Program.uiConfig.Remind = this.cbRemind.Checked;
            if (!cbRemind.Checked)
                runTime = 0;
        }
        private void cbStartUp_CheckedChanged(object sender, EventArgs e)
        {
            Program.uiConfig.StartUp = this.cbStartUp.Checked;
            SystemApi.SetAutoStart(this.cbStartUp.Checked);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitWriteConfig();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Text = GetProcessPath(SystemApi.GetForegroundWindow()).ToString() ;
        }

    }
}
