using System;
using System.IO;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace TimeLogger
{
    public static class JsonExtension
    {
        static object lockObj = new object();
        /// <summary>
        /// 读取文件中的Json数据
        /// </summary>
        /// <param name="pathName">文件路径名</param>
        /// <returns>返回Json数据</returns>
        public static string ReadJsonFile(this String pathName)
        {
            StreamReader sr = File.OpenText(pathName);
            string configStr = sr.ReadToEnd();
            sr.Close();
            return configStr.Replace("\\\\", "\\").Replace("\\", "\\\\");
        }

        /// <summary>
        /// 写入Json数据到文件
        /// </summary>
        /// <param name="pathName">文件路径名</param>
        /// <param name="data">Json数据</param>
        public static void WriteJsonFile(this String pathName, string data)
        {
            lock (lockObj)
            {
                File.WriteAllText(pathName, data);
            }

        }
    }
}
