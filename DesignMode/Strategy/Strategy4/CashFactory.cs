﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy4
{
    /// <summary>
    /// 现金收费工厂类，准确应该叫 收费对象生成工厂类
    /// </summary>
    class CashFactory
    {
        public static CashSuper CreateCashAccept(string type)
        {
            CashSuper cs = null;
            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300返80":
                    cs = new CashReturn("300", "80");
                    break;
                case "打八折":
                    cs = new CashRebate("0.8");
                    break;
                case "打五折":
                    cs = new CashRebate("0.5");
                    break;
                case "满500送200":
                    cs = new CashReturn("500", "200");
                    break;
            }
            return cs;
        }
    }
}
