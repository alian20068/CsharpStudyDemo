using System;

namespace LockDemo
{
    using Model;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var account = new Account(1000);
            var arrTask = new Task[5];

            for (int i = 0; i < arrTask.Length; i++)
            {
                arrTask[i] = Task.Run(
                    () => RandomlyUpdate(account)
                    );
            }

            Task.WaitAll(arrTask);
        }

        static void RandomlyUpdate(Account account)
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var amount = rnd.Next(1, 100);
                var doCredit = rnd.NextDouble() < 0.5;
                if (doCredit)
                    account.Credit(amount);
                else
                    account.Debit(amount);
            }
        }

    }
}
