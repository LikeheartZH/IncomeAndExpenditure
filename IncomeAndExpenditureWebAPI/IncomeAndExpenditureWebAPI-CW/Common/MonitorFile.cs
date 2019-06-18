using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW.Common
{
    /// <summary>
    /// 文件监控
    /// </summary>
    public class MonitorFile
    {
        /// <summary>
        /// 监控配置文件  
        /// 配置文件修改后，重新读取配置
        /// </summary>
        /// <param name="path">配置文件所在路径</param>
        /// <param name="settings">配置文件节点</param>
        public static void MonitorConfig(string path, string[] settings)
        {
            FileSystemWatcher fsWatcher = new FileSystemWatcher(path, "*.config");
            fsWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fsWatcher.Changed += (s, e) =>
            {
                try
                {
                    settings.ToList().ForEach((setting) =>
                    {
                        ConfigurationManager.RefreshSection(setting);
                    });
                }
                catch { }
            };
            fsWatcher.EnableRaisingEvents = true;
        }

    }
}
