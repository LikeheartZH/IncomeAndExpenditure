using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureWebAPI_CW.Common
{

    public class CommonHelper
    {
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
    }
}
