using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy5
{
    /// <summary>
    /// 具体算法B
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法 B 实现");
        }
    }
}
