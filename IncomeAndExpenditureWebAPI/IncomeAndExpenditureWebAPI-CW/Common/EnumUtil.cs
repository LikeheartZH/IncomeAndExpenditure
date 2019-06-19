using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW.Common
{
    /// <summary>
    /// 通用枚举
    /// </summary>
    public class EnumUtil
    {
        #region 收入类型
        /// <summary>
        /// 收入类型
        /// </summary>
        public enum IncomeType
        {
            工资 = 0,
            年终 = 1,
            其他 = 99,
        }
        #endregion

        #region 错误码
        /// <summary>
        /// 错误码
        /// </summary>
        public enum ErrorCode
        {
            /// <summary>
            /// 未获得授权
            /// </summary>
            [DescriptionAttribute("未获得授权,请获取Token")]
            NoAuth = -1,
            /// <summary>
            /// 请求成功
            /// </summary>
            [DescriptionAttribute("请求成功")]
            Success = 0,
            /// <summary>
            /// 未知错误
            /// </summary>
            [DescriptionAttribute("未知错误")]
            NotKnowError = 99,
        }
        #endregion
    }
}