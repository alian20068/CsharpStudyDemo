using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribe1
{
    /// <summary>
    /// 前台秘书
    /// </summary>
    class Secretary
    {
        //同事列表
        private IList<StockObserver> observers = new List<StockObserver>();

        /// <summary>
        /// 前台状态
        /// </summary>
        public string SecretaryAction { get; set; }

        /// <summary>
        /// 添加同事
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(StockObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 通知同事
        /// </summary>
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

    }
}
