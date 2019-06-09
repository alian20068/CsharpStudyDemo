using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy3
{
    /// <summary>
    /// 返利收费子类
    /// </summary>
    class CashReturn : CashSuper
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;

        /// <summary>
        /// 返利收费，初始化时，必须要输入返利条件和返利金额，比如满300返80，则 moneyCondition为300,moneyReturn为80
        /// </summary>
        /// <param name="moneyCondition"></param>
        /// <param name="moneyReturn"></param>
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = double.Parse(moneyCondition);
            this.moneyReturn = double.Parse(moneyReturn);
        }

        public override double AcceptCash(double money)
        {
            double result = money;

            if (money >= moneyCondition)
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;

            return result;
        }
    }
}
