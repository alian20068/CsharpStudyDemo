using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    /// <summary>
    /// 除法类
    /// </summary>
    class CalculateDiv : CalculateBase
    {
        public override double GetResult()
        {
            if (NumberB == 0)
                throw new Exception("除数不能为0");
            return NumberA / NumberB;
        }
    }
}
