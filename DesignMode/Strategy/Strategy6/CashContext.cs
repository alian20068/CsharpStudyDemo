using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy6
{
    /// <summary>
    /// 上下文
    /// </summary>
    class CashContext
    {
        private CashSuper _CashSuper;

        /// <summary>
        /// 通过构造函数，传入具体的收费策略
        /// </summary>
        /// <param name="cashSuper"></param>
        public CashContext(CashSuper cashSuper)
        {
            this._CashSuper = cashSuper;
        }

        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public double GetResult(double money)
        {
            //根据收费策略的不同，获取计算结果
            return _CashSuper.AcceptCash(money);
        }
    }
}
