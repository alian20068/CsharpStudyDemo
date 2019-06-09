using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy7
{
    /// <summary>
    /// 打折收费子类
    /// </summary>
    class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;

        /// <summary>
        /// 打折收费，初始化时，必需要输入折扣率，如八折，就是 0.8
        /// </summary>
        /// <param name="moneyRebate"></param>
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = double.Parse(moneyRebate);
        }

        public override double AcceptCash(double money)
        {
            return money * moneyRebate;
        }
    }
}
