using System;
using System.Collections.Generic;
using System.Text;

namespace LockDemo.Model
{
    public class Account
    {
        private readonly object lockObj = new object();
        private decimal balance;

        public Account(decimal initialBalance)
        {
            balance = initialBalance;
        }

        /// <summary>
        /// 扣
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal Debit(decimal amount, int index)
        {
            lock (lockObj)
            {
                if (balance >= amount)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append($"{balance,5}-{amount,5}=");
                    balance = balance - amount;
                    s.Append($"{balance,5}");//等同于string.Format("{0,5}", balance);//指定字符串宽度为5，右对齐
                    s.Append($" 线程号{index}");
                    Console.WriteLine(s.ToString());
                    
                    return amount;
                }
                else
                    return 0;
            }
        }

        /// <summary>
        /// 加
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(decimal amount, int index)
        {
            lock (lockObj)
            {
                StringBuilder s = new StringBuilder();
                s.Append($"{balance,5}+{amount,5}=");
                balance = balance + amount;
                s.Append($"{balance,5}");
                s.Append($" 线程号{index}");
                Console.WriteLine(s.ToString());
            }
        }

    }
}
