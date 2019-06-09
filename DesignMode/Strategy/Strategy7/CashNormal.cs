using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy7
{
    /// <summary>
    /// 正常收费子类
    /// </summary>
    class CashNormal : CashSuper
    {
        /// <summary>
        /// 正常收费，原价返回
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override double AcceptCash(double money)
        {
            return money;
        }
    }
}
