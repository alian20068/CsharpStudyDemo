using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribe1
{
    /// <summary>
    /// 观察者：玩股票同事
    /// </summary>
    class StockObserver
    {
        private string name;
        private Secretary sub;

        public StockObserver(string name,Secretary sub)
        {
            this.name = name;
            this.sub = sub;
        }

        public void Update()
        {
            Console.WriteLine("{0} {1} 快关闭股票，继续工作", sub.SecretaryAction, name);
        }

    }
}
