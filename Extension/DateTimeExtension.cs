using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogger
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="unixTimeStamp">Unix时间戳</param>
        /// <returns></returns>
        public static DateTime TimeStampToDateTime(this string unixTimeStamp)
        {
            return TimeStampToDateTime(unixTimeStamp.ToInt32());
        }

        /// <summary>
        /// 将Unix时间戳转成DateTime
        /// </summary>
        /// <param name="timestamp">13位或10位时间戳</param>
        /// <returns>DateTime</returns>
        public static DateTime TimeStampToDateTime(this int timestamp)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            startTime = startTime.AddSeconds(timestamp);
            return startTime;
        }

        /// <summary>
        /// 将指定时间转换为Unix时间戳
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static int ToUnixTimeStamp(this DateTime dateTime)
        {
            double intResult = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (dateTime - startTime).TotalSeconds;
            return intResult.ToInt32();
        }

        /// <summary>
        /// 时间戳转换为*天*小时*分钟*秒
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        public static string TimeStampToDayHoursSeconds(this int timeStamp)
        {
            TimeSpan ts = new TimeSpan(0, 0, timeStamp);
            return $"{ts.Days}天{ts.Hours}小时{ts.Minutes}分钟{ts.Seconds}秒";
        }

        /// <summary>
        /// 天数转换为时间戳
        /// </summary>
        /// <param name="dayTime"></param>
        /// <returns></returns>
        public static string DayTimeToTimeStamp(this int dayTime)
        {
            return (dayTime * 86400).ToString();
        }
        /// <summary>
        /// 超时检测,单位（秒）
        /// </summary>
        /// <param name="checkStartTimeStamp">开始检测时间戳</param>
        /// <param name="outTime">检测时间，单位（秒）</param>
        /// <returns>超时返回true；否则返回false</returns>
        public static bool OutTimeCheck(this int checkStartTimeStamp, int outTime)
        {
            return DateTime.Now.ToUnixTimeStamp() - checkStartTimeStamp > outTime;
        }
        /// <summary>
        /// 过去已经执行多少秒
        /// </summary>
        /// <param name="startTime">开始时间戳</param>
        /// <returns>返回已经开始多少秒</returns>
        public static int GetStartHowSeconds(this int startTime)
        {
            return DateTime.Now.ToUnixTimeStamp() - startTime;
        }
    }
}
