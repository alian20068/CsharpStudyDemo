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
                    () => RandomlyUpdate(account, i)
                    );
            }

            Task.WaitAll(arrTask);
        }

        static void RandomlyUpdate(Account account, int index)
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var amount = rnd.Next(1, 100);
                var doCredit = rnd.NextDouble() < 0.5;
                if (doCredit)
                    account.Credit(amount, index);
                else
                    account.Debit(amount, index);
            }
        }

    }
}
