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
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //监控配置文件中appSettings节点变更后，从磁盘重新读取
            MonitorFile.MonitorConfig(AppDomain.CurrentDomain.BaseDirectory, new[] { "appSettings" });


            //TODO：全局异常捕获


            //启动服务
            HostFactory.Run(c =>
            {
                c.RunAsLocalSystem();
                c.SetServiceName("HostService");//服务名称
                c.SetDisplayName("A_收支记录_WebApi宿主");//显示名称
                c.SetDescription("用于记录个人收支的服务");//描述
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