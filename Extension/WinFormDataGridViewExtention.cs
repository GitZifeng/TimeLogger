using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TimeLogger
{
    public static class WinFormDataGridViewExtention
    {
        /// <summary>
        /// 更新DataGridView
        /// </summary>
        /// <typeparam name="T">需要更新的数据类型</typeparam>
        /// <param name="dgv">DataGridView对象</param>
        /// <param name="data">数据对象</param>
        public static void Update<T>(this DataGridView dgv, T data)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = null;
            dgv.DataSource = data;
            dgv.Refresh();
        }

        /// <summary>
        /// DataGridView双缓冲
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void DataGridViewDoubleBuffered(this System.Windows.Forms.DataGridView dgv)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);
        }
    }
}
