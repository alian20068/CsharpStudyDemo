using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    /// <summary>
    /// 乘法类
    /// </summary>
    class CalculateMul : CalculateBase
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
}
