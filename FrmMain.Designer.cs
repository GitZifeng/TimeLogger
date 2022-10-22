namespace TimeLogger
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbRemind = new System.Windows.Forms.CheckBox();
            this.cbStartUp = new System.Windows.Forms.CheckBox();
            this.AppICO = new System.Windows.Forms.DataGridViewImageColumn();
            this.AppTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseDurationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppICO,
            this.AppTitle,
            this.UseDurationTime});
            this.dgv.Location = new System.Drawing.Point(1, 1);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(579, 300);
            this.dgv.TabIndex = 0;
            // 
            // cbRemind
            // 
            this.cbRemind.AutoSize = true;
            this.cbRemind.Location = new System.Drawing.Point(6, 315);
            this.cbRemind.Name = "cbRemind";
            this.cbRemind.Size = new System.Drawing.Size(240, 16);
            this.cbRemind.TabIndex = 1;
            this.cbRemind.Text = "运行20分钟提示休息20秒【防止眼疲劳】";
            this.cbRemind.UseVisualStyleBackColor = true;
            this.cbRemind.CheckedChanged += new System.EventHandler(this.cbRemind_CheckedChanged);
            // 
            // cbStartUp
            // 
            this.cbStartUp.AutoSize = true;
            this.cbStartUp.Location = new System.Drawing.Point(6, 337);
            this.cbStartUp.Name = "cbStartUp";
            this.cbStartUp.Size = new System.Drawing.Size(96, 16);
            this.cbStartUp.TabIndex = 1;
            this.cbStartUp.Text = "跟随系统自启";
            this.cbStartUp.UseVisualStyleBackColor = true;
            this.cbStartUp.CheckedChanged += new System.EventHandler(this.cbStartUp_CheckedChanged);
            // 
            // AppICO
            // 
            this.AppICO.DataPropertyName = "AppICO";
            this.AppICO.HeaderText = "图标";
            this.AppICO.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.AppICO.Name = "AppICO";
            this.AppICO.ReadOnly = true;
            this.AppICO.Width = 40;
            // 
            // AppTitle
            // 
            this.AppTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AppTitle.DataPropertyName = "AppTitle";
            this.AppTitle.HeaderText = "应用标题";
            this.AppTitle.Name = "AppTitle";
            this.AppTitle.ReadOnly = true;
            // 
            // UseDurationTime
            // 
            this.UseDurationTime.DataPropertyName = "UseDurationTime";
            this.UseDurationTime.HeaderText = "使用时长";
            this.UseDurationTime.Name = "UseDurationTime";
            this.UseDurationTime.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 364);
            this.Controls.Add(this.cbStartUp);
            this.Controls.Add(this.cbRemind);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeLogger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckBox cbRemind;
        private System.Windows.Forms.CheckBox cbStartUp;
        private System.Windows.Forms.DataGridViewImageColumn AppICO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn UseDurationTime;
    }
}

