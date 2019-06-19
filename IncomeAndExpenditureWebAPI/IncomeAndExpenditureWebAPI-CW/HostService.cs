using IncomeAndExpenditureWebAPI_CW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW
{
    /// <summary>
    /// Windows服务
    /// </summary>
    public class HostService
    {
        #region 开启
        /// <summary>
        /// 开启
        /// </summary>
        public void Start()
        {
            Console.WriteLine("【开启】- HostService");
            LogHelper.WriteInfoLog("【开启】- HostService");
            WebApiSelfHost.Start();
        }
        #endregion

        #region 停止
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            WebApiSelfHost.Stop();
            Console.WriteLine("【停止】- HostService");
            LogHelper.WriteInfoLog("【停止】- HostService");
        } 
        #endregion
    }
}