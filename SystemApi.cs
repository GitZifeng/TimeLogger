using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace TimeLogger
{
    public static class SystemApi
    {


        //获取当前置顶窗口(窗口总在最前,类似于QQ那种)
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public  static string GetActiveAppName()
        {
            var pros = Process.GetProcesses();
            foreach (var pro in pros)
            {
                if (pro.MainWindowHandle.ToInt32() == 0)
                    continue;
                if (pro.MainWindowHandle == SystemApi.GetForegroundWindow())
                {
                    //if(pro.ProcessName!="")
                    //    return pro.ProcessName;
                    return pro.MainWindowTitle;
                }
            }
            return "";
        }

        /// <summary>
        /// 是否设置程序为开机启动界面
        /// </summary>
        /// <param name="appPath">程序启动路径</param>
        /// <param name="nodelist">true为设置为启动桌面,false为重新设置为操作系统界面</param>
        /// <returns>修改成功返回true</returns> 
        public static bool IsSetDesktop(string appPath, bool isSetDesktop)
        {
            bool ret = false;
            RegistryKey reg = null;
            try
            {
                reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", false);
                if (isSetDesktop)
                {
                    if (null == reg)
                    {
                        reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                    }
                    reg.SetValue("Shell", appPath);
                    ret = true;
                }
                else
                {
                    reg.SetValue("Shell", "explorer.exe");//explorer.exe为操作系统显示桌面的exe程序
                }
            }
            catch (Exception e)
            {
                throw new Exception("Set System Desktop error:" + e.Message);
            }
            finally
            {
                if (null != reg)
                {
                    reg.Close();
                }
            }
            return ret;
        }

        /// <summary>
        /// 设置开机自动启动
        /// </summary>
        /// <param name="onOff"></param>
        public static void SetAutoStart(bool onOff)
        {
            if (onOff)
            {
                //设置开机自启动  
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("TimeLogger", path);
                rk2.Close();
                rk.Close();
            }
            else
            {
                //"取消开机自启动
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("TimeLogger", false);
                rk2.Close();
                rk.Close();
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out uint processId);
        public static string GetProcessPath(IntPtr hwnd)
        {
            Process process = null;
            try
            {
                uint pid = 0;
                GetWindowThreadProcessId(hwnd, out pid);
                //由进程ID得到进程
                process = Process.GetProcessById((int)pid);
                //此处会失败，会报出 程序以32位平台运行时取64位程序的进程路径会异常 故用try catch块儿包起来
                return process.MainModule.FileName;
            }
            catch (Exception)
            {

            }
            return "";
        }

        
    }
}
