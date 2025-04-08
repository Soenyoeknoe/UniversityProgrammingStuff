using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class Savings:Account
    {
        public Savings() : base()
        {
        }

        public override bool deposit(double amount)//overide method of deposit
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("\t\tYou account balance has been deposited.");
            Console.WriteLine("\t\tBalance is: $" + balance);
            return true;
        }

        public override bool withdraw(double amount)//overide method of withdraw
        {
            this.ammount = amount;
            this.balance = balance - ammount;
            Console.WriteLine("\t\tYou account balance has been withdrawed.");
            Console.WriteLine("\t\tBalance is: $" + balance);
            return true;
        }
    }
}

