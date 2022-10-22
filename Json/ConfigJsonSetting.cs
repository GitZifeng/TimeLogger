using Newtonsoft.Json;
using System.IO;

namespace TimeLogger
{
    public class ConfigJsonSetting
    {
        private string SettingPath = "";
        public ConfigJsonSetting(string path)
        {
            if (!File.Exists(path))
            {
                using (var file = File.Create(path))
                {
                    file.Close();
                }
            }
            SettingPath = path;
        }
        /// <summary>
        /// 读取Setting配置文件
        /// </summary>
        /// <returns></returns>
        public T ReadSetting<T>()
        {
            return JsonConvert
                .DeserializeObject<T>(SettingPath.ReadJsonFile());
        }

        /// <summary>
        /// 写入Setting配置文件
        /// </summary>
        /// <param name="globalSetting"></param>
        public void WriteSetting<T>(T globalSetting)
        {
            SettingPath.WriteJsonFile(JsonConvert.SerializeObject(globalSetting));
        }
    }
}
