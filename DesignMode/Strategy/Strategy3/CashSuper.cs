using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy3
{
    /// <summary>
    /// 现金收费抽象类
    /// </summary>
    abstract class CashSuper
    {
        /// <summary>
        /// 现金收费抽象类的抽象方法，收取现金，参数为原价，返回为当前价
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public abstract double AcceptCash(double money);
    }
}
