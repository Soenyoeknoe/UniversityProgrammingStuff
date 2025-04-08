using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    abstract class Account
    {
        public readonly string name;
        public double balance;
        public double ammount;
        public abstract bool deposit(double amount);//abtract class for deposit

        public abstract bool withdraw(double amount);//abstract class for withdraw

        public double getBalance()
        {
            return balance;
        }
        public string getAccType()
        {
            string actype;
            actype = Convert.ToString(Console.ReadLine());
            return actype;
        }
        public void printAccount()
        {

            Console.WriteLine("Name : " + name);
            Console.WriteLine("Balance :" + balance);
        }
        public Account()
        {

        }
        public Account(string name, double balance)//asign name and balance of account
        {
            this.name = name;
            this.balance = balance;
        }
    }
}

