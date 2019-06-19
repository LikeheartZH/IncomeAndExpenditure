using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW
{
    public class HostService
    {
        public void Start()
        {
            Console.WriteLine("【开启】- HostService");
            WebApiSelfHost.Start();
        }

        public void Stop()
        {
            WebApiSelfHost.Stop();
            Console.WriteLine("【停止】- HostService");
        }

    }
}
