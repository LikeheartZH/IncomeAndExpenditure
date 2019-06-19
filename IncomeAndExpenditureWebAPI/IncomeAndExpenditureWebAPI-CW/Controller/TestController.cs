using IncomeAndExpenditureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IncomeAndExpenditureWebAPI_CW.Controller
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string GetValue(int num)
        {
            string value = (num + 1).ToString();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " GetValue()执行,执行结果：" + value);
            return value;
        }

        [HttpGet]
        public string GetName()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " GetName()执行");
            return "your name is Bob？";
        }

        public string GetVersion()
        {
            return new BaseResponseModel().Version;
        }
    }
}
