using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class Credit:Account
    {
        public double minBalance = -100000;
        private double dailyWithdrawLimit = 20000;
        public Credit() : base()
        {
        }
        public Credit(string name, double balance) : base(name, balance)
        {
        }
        public override bool deposit(double amount)//overide method of deposit
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("\t\tYou account balance has been deposited. ");
            Console.WriteLine("\t\tBalance is: $" + balance);
            return true;
        }
        public override bool withdraw(double amount)//overide method of withdraw
        {
            this.ammount = amount;
            if (amount < this.minBalance)
            {
                Console.WriteLine("\t\tYour Account don't have sufficient amount of money!");
                return false;
            }
            else if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("\t\tYou can not withdraw more than 20000.");//only able to withdraw no more than $20000
                return false;
            }
            else
            {
                this.balance = balance - ammount;
                Console.WriteLine("\t\tYou account balance has been withdrawed. ");
                Console.WriteLine("\t\tBalance is: $" + balance);
                return true;
            }
        }
    }
}

