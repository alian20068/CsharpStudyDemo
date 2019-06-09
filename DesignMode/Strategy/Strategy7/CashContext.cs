using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy7
{
    /// <summary>
    /// 上下文
    /// </summary>
    class CashContext
    {
        private CashSuper _CashSuper;

        /// <summary>
        /// 通过构造函数，传入类型
        /// </summary>
        /// <param name="type"></param>
        public CashContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    _CashSuper = new CashNormal();
                    break;
                case "满300返80":
                    _CashSuper = new CashReturn("300", "80");
                    break;
                case "打八折":
                    _CashSuper = new CashRebate("0.8");
                    break;
            }
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
