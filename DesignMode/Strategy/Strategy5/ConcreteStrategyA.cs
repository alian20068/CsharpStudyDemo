using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy5
{
    /// <summary>
    /// 具体算法A
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法 A 实现");
        }
    }
}
