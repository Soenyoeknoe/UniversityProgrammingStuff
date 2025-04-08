using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BMS
{
    class Login
    {
        Menu mn = new Menu();
        public void loginScrn()
        {
            bool checkCredential = false;//variable to check credential
            Console.Clear();
            Console.WriteLine("\t\t╒===================================╕");//UI for input username and password
            Console.WriteLine("\t\t|  WELCOME TO SIMPLE BANKING SYSTEM |");
            Console.WriteLine("\t\t|===================================|");
            Console.WriteLine("\t\t|          LOGIN TO START           |");
            Console.WriteLine("\t\t|                                   |");
            Console.Write("\t\t|   Username: ");
            int userNameleft = Console.CursorLeft;
            int userNametop = Console.CursorTop;
            Console.Write("                      |");

            Console.WriteLine("\n\t\t|                                   |");
            Console.Write("\t\t|   Password: ");
            int passWordleft = Console.CursorLeft;
            int passWordtop = Console.CursorTop;
            Console.Write("                      |");
            Console.WriteLine("\n\t\t|                                   |");
            Console.WriteLine("\t\t╙-----------------------------------╛");
            Console.WriteLine("\t\t P.S. to register new credentials, and log in with same credentials ");
            Console.SetCursorPosition(userNameleft, userNametop);
            string inputUserName = Convert.ToString(Console.ReadLine());
            Console.SetCursorPosition(passWordleft, passWordtop);
            string inputpassword = "";
            ConsoleKey key;//change the password key into "*"
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && inputpassword.Length > 0)
                {
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    inputpassword += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            List<Credentials> lgnCredentials = new List<Credentials>();//put the account credential into list
            List<string> lgnlines = File.ReadAllLines("login.txt").Reverse().ToList();//read all line of the login.txt file
            foreach (var lgnline in lgnlines)//loop through each line in text file
            {
                string[] entries = lgnline.Split(" | "); // split username and password
                Credentials credentials = new Credentials();
                credentials.UserName = entries[0];//put username into the index of 0
                credentials.Password = entries[1];//put password into the index of 1
                lgnCredentials.Add(credentials);
                if (inputUserName.Equals(credentials.UserName) && inputpassword.Equals(credentials.Password))//to check if the credential inputted matched the txt file
                {
                    checkCredential = true;
                }
                else
                { 

                }
            }
            if(checkCredential == true)
            {
                    Console.WriteLine("\n\n\n\t\t Valid Credentials!........               Press any key to continue...");//return true if the credential is correct
                    Console.ReadKey(true);
                    mn.menuScrn();
            }
            else if (checkCredential == false)
            {
                    Console.WriteLine("\n\n\n\t\t Invalid Username or password!...  Please press any key to re-enter...");//return false if the credential is false
                    Console.ReadKey();
                    using (StreamWriter lgnDataWriter = File.AppendText("login.txt"))//input the false credential into txt file as new data in database
                    {
                        lgnDataWriter.WriteLine(inputUserName + " | " + inputpassword);
                    }
                    loginScrn();//re-login again
            } 
        }

    }

}

