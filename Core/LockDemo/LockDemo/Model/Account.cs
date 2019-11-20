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

        public decimal Debit(decimal amount)
        {
            lock (lockObj)
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"借前:{balance,5}");
                    Console.WriteLine($"借走:{amount,5}");
                    balance = balance - amount;
                    Console.WriteLine($"借后:{balance,5}");
                    
                    return amount;
                }
                else
                    return 0;
            }
        }

        public void Credit(decimal amount)
        {
            lock (lockObj)
            {
                Console.WriteLine($"贷前:{balance,5}");
                Console.WriteLine($"贷来:{amount,5}");
                balance = balance + amount;
                Console.WriteLine($"贷后:{balance,5}");
            }
        }

    }
}
