using IncomeAndExpenditureModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW.Common
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public class CommonHelper
    {
        #region 获取类上的Description
        /// <summary>
        /// 获取类上的Description
        /// </summary>
        public static string GetDescription(Type type)
        {
            try
            {
                object[] attribArray = type.GetCustomAttributes(false);
                DescriptionAttribute attrib = (DescriptionAttribute)attribArray[0];
                return attrib.Description;
            }
            catch { return string.Empty; }
        }
        #endregion

        #region 获取枚举上的Description
        /// <summary>  
        /// 获取枚举上的Description
        /// </summary>  
        public static string GetDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes =
                      (DescriptionAttribute[])fi.GetCustomAttributes(
                      typeof(DescriptionAttribute), false);

                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }
            catch { return string.Empty; }
        }
        #endregion

        #region 通用方法执行
        /// <summary>
        /// 通用方法执行
        /// 有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="funcName">方法名</param>
        /// <returns></returns>
        public T Run<T>(Func<T> func, string funcName, string param = "") where T : BaseResponseModel
        {
            LogHelper.WriteInfoLog(" 开始执行方法：" + funcName);
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            T result = default(T);
            try
            {
                result = func();
            }
            catch (Exception ex)
            {
                #region 记录异常信息和设置返回值
                LogHelper.WriteErrorLog(funcName, ex, param);
                result = new BaseResponseModel()
                {
                    ErrorCode = (int)EnumUtil.ErrorCode.NotKnowError,
                    ErrorMsg = GetDescription(EnumUtil.ErrorCode.NotKnowError)
                } as T;
                #endregion
            }
            finally
            {
                #region 记录执行耗时和请求参数
                sWatch.Stop();
                string info = string.Format("方法【{0}】执行耗时【{1}】毫秒", funcName, sWatch.ElapsedMilliseconds.ToString());
                if (!string.IsNullOrWhiteSpace(param))
                {
                    info += ",【参数】：" + param;
                }
                LogHelper.WriteInfoLog(info);
                #endregion
            }
            return result;
        }
        #endregion
    }
}