using IncomeAndExpenditureWebAPI_CW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace IncomeAndExpenditureWebAPI_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            //监控配置文件中appSettings节点变更后，从磁盘重新读取
            MonitorFile.MonitorConfig(AppDomain.CurrentDomain.BaseDirectory, new[] { "appSettings" });

            //HostFactory.Run(c =>
            //{
            //    c.RunAsLocalSystem();
            //    c.SetServiceName("UpdateSysTime");
            //    c.SetDisplayName("更新系统时间");
            //    c.SetDescription("获取网络时间,更新系统时间");

            //    c.Service<CheckTimeService>(s =>
            //    {
            //        s.ConstructUsing(b => new CheckTimeService());
            //        s.WhenStarted(o => o.Start());
            //        s.WhenStopped(o => o.Stop());
            //    });
            //});

            Console.ReadKey();
        }
    }
}
