using System;

namespace PublishSubscribe1
{
    class Program
    {
        static void Main(string[] args)
        {
            //前台
            Secretary qiantai = new Secretary();
            //看股票的同事
            StockObserver tongshi1 = new StockObserver("张三", qiantai);
            StockObserver tongshi2 = new StockObserver("李四", qiantai);

            //前台记录要通知的同事
            qiantai.Attach(tongshi1);
            qiantai.Attach(tongshi2);

            //发现老板回来了
            qiantai.SecretaryAction = "老板回来了，";
            //通知同事们
            qiantai.Notify();

            Console.Read();
        }
    }
}
