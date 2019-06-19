using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeAndExpenditureModel
{
    /// <summary>
    /// 
    /// </summary>
    [Description("银行")]
    public class BankModel : BaseResponseModel
    {
        /// <summary>
        /// 银行ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string Name { get; set; }
    }
}