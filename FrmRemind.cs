using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class FrmRemind : Form
    {
        int time = 21;
        public FrmRemind()
        {
            InitializeComponent();
        }

        private void FrmRemind_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.lblMsg.PointToClient();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time != 0)
            {
                time--;
                this.lblMsg.Text = $"让眼睛休息下吧!{time}秒后关闭窗口";
                var fromPoint = this.Size;
                var lbMsg = this.lblMsg.Size;

                int fw = fromPoint.Width / 2;
                int fh = fromPoint.Height / 2;

                int lw = lbMsg.Width / 2;
                int lh = lbMsg.Height / 2;
                this.lblMsg.Location = new Point(fw - lw, fh - lh);
            }
            else
            {
                this.Close();
                Program.frmRemind = null;
            }
      
        }
    }
}
