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

            HostFactory.Run(c =>
            {
                c.RunAsLocalSystem();
                c.SetServiceName("HostService");//服务名称
                c.SetDisplayName("A_收支记录_WebApi宿主");//显示名称
                c.SetDescription("WebApi宿主,用于收支记录服务");//描述
                c.Service<HostService>(s =>
                {
                    s.ConstructUsing(b => new HostService());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });
            });
        }
    }
}
