using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW.Common
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        private static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("DEBUG");

        #region 记录运行日志
        /// <summary>
        /// 记录运行日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteInfoLog(string info)
        {
            Logerror.Info(info);
        }
        #endregion

        #region 记录错误日志
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteErrorLog(string info)
        {
            Logerror.Error(info);
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="funcName">方法名</param>
        /// <param name="ex">异常</param>
        /// <param name="param">参数</param>
        public static void WriteErrorLog(string funcName, Exception ex, string param = "")
        {
            if (string.IsNullOrWhiteSpace(param))
                Logerror.Error(string.Format("方法：{0} 错误：{1}", funcName, ex));
            else
                Logerror.Error(string.Format("方法：{0} 错误：{1} 参数：{2}", funcName, ex, param));
        }
        #endregion

        #region 记录调试日志
        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteDebugLog(string info)
        {
            Logerror.Debug(info);
        }
        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="exception"></param>
        public static void WriteDebugLog(Exception exception)
        {
            Logerror.Debug(exception.Message, exception);
        }
        #endregion
    }
}