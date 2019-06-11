using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    /// <summary>
    /// 加法类
    /// </summary>
    class CalculateAdd : CalculateBase
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
}
