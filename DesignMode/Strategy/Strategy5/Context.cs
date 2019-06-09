using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy5
{
    /// <summary>
    /// 上下文
    /// </summary>
    class Context
    {
        Strategy _Strategy;
        /// <summary>
        /// 初始化时，传入具体的策略对象
        /// </summary>
        /// <param name="strategy"></param>
        public Context(Strategy strategy)
        {
            this._Strategy = strategy;
        }

        /// <summary>
        /// 上下文接口，根据具体的策略对象，调用其算法的实现
        /// </summary>
        public void ContextInterface()
        {
            _Strategy.AlgorithmInterface();
        }
    }
}
