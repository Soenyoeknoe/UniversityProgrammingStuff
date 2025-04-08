using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class Debit:Account
    {
        public double maxBalance = 100000;
        private double dailyTransLimit = 20000;
        public Debit() : base()
        {
        }
        public Debit(string name, double balance) : base(name, balance)
        {
        }
        public override bool deposit(double amount)//overide method of deposit
        {
            this.ammount = amount;
            if (amount > maxBalance)
            {
                Console.WriteLine("\t\tYou can not deposit more than 100000!");//can only deposit less than $1000000
                return false;
            }
            else
            {
                this.balance = balance + ammount;
                Console.WriteLine("\t\tYou account balance has been deposited. Balance is: $" + balance);
                return true;
            }
        }
        public override bool withdraw(double amount)//overide method of witdraw
        {
            this.ammount = amount;

            if (amount > dailyTransLimit)
            {
                Console.WriteLine("\t\tYou can not withdraw more than 20000.");//only able to withdraw no more than $20000
                return false;
            }
            else if (amount > maxBalance)
            {
                Console.WriteLine("\t\tYou can not withdraw that amount of money!");
                return false;
            }
            else
            {
                this.balance = balance - ammount;
                Console.WriteLine("\t\tYou account balance has been withdrawed. Balance is: $" + balance);
                return true;
            }
        }
    }
}

