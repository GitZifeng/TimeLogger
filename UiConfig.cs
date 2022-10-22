using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogger
{
    public class UiConfig
    {
        /// <summary>
        /// 20分钟提醒
        /// </summary>
        public bool Remind { get; set; }
        /// <summary>
        /// 开机自启
        /// </summary>
        public bool StartUp { get; set; }
    }
}
