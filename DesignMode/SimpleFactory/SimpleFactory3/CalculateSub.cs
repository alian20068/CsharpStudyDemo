using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    /// <summary>
    /// 减法类
    /// </summary>
    class CalculateSub : CalculateBase
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}
