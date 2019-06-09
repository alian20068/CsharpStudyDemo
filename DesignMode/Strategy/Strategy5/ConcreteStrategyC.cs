using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy5
{
    /// <summary>
    /// 具体算法C
    /// </summary>
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法 C 实现");
        }
    }
}
