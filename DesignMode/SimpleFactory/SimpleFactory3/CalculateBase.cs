using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    /// <summary>
    /// 算法基础类
    /// </summary>
    class CalculateBase
    {
        public double NumberA { get; set; }

        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            return 0d;
        }
    }
}
