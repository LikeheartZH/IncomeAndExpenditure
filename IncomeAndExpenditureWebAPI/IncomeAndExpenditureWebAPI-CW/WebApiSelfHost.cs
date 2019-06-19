using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace IncomeAndExpenditureWebAPI_CW
{
    public static class WebApiSelfHost
    {
        private static HttpSelfHostServer server;

        public static void Start()
        {
            string baseAddress = "http://localhost:8080";
            Console.WriteLine(baseAddress);
            var config = new HttpSelfHostConfiguration(baseAddress); //配置主机
            config.Routes.MapHttpRoute(
               name: "API Default",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional });
            server = new HttpSelfHostServer(config); //监听HTTP
            server.OpenAsync().Wait(); //开启来自客户端的请求
            Console.WriteLine("开启Http监听");
        }

        public static void Stop()
        {
            if (server != null)
            {
                server.CloseAsync().Wait();
                server.Dispose();
                Console.WriteLine("关闭Http监听");
            }
        }
    }
}
