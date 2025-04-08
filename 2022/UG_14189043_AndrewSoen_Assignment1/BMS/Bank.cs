using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;

namespace BMS
{
    class Bank
    {
        //variable
        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myFirstName = new string[100];
        public string[] myLastName = new string[100];
        public string[] myAccType = new string[100];
        public double[] myBalance = new double[100];
        public string[] myPhone = new string[100];
        public string[] myEmail = new string[100];
        public string[] myAddress = new string[100];

        //connect this file with other file in this folder
        IDGenerator Id = new IDGenerator();
        DOB dob = new DOB();
        Credit cr = new Credit();
        Debit db = new Debit();
        Savings sv = new Savings();
        Menu mn = new Menu();
        DateTime date = DateTime.Now;

        public bool val = true;//variable to check if val is true
        public bool debval = true;//variable to check if deval is true
        int transactions = 0;//variable to check num of transactions
        
        
        private void GetAcc(string ID)//method to do increament of ID
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;

        }
        public void create_account()
        {
            string input;
            Console.Clear();
            Console.WriteLine("\t\t╒===================================╕");//UI for account Type
            Console.WriteLine("\t\t|         CREATE NEW ACCOUNT        |");
            Console.WriteLine("\t\t|===================================|");
            Console.WriteLine("\t\t|        Choose Account Type        |");
            Console.WriteLine("\t\t|   1. Debit Account                |");
            Console.WriteLine("\t\t|   2. Credit Account               |");
            Console.WriteLine("\t\t|   3. Savings Account              |");
            Console.WriteLine("\t\t|===================================|");
            Console.Write("\t\t| Enter your choice (1-3): ");
            int ChoiceCursorX = Console.CursorLeft;
            int ChoiceCursorY = Console.CursorTop;
            Console.Write("         |");
            Console.Write("\n\t\t╙-----------------------------------╛");
            Console.SetCursorPosition(ChoiceCursorX, ChoiceCursorY);

            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "1")
            {
                debit();

            }
            else if (input == "2")
            {
                credit();
            }
            else if (input == "3")
            {
                savings();
            }
            else
            {
                Console.WriteLine("\n\n\t\tError: invalid choice... Press any key to re-enter");//show erroe message that the choices is invalid as there were none in menu
                Console.ReadKey(true);
                create_account();
            }

        }
        public void debit()
        {
            string accType;
            string firstName;
            string lastName;
            string email;
            string phone;
            string address;
            Console.Clear();
            accType = "Debit";
            myAccType[idnum] = accType;
            Console.WriteLine("\t\t╒=============================================╕");//UI for create debit account
            Console.WriteLine("\t\t|              CREATE DEBIT ACCOUNT           |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|               Enter Your Details            |");
            Console.Write("\t\t|     First Name: ");
            int debFNameleft = Console.CursorLeft;
            int debFNametop = Console.CursorTop;
            Console.Write("                            |");
            Console.Write("\n\t\t|     Last Name: ");
            int debLNameleft = Console.CursorLeft;
            int debLNametop = Console.CursorTop;
            Console.Write("                             |");
            Console.Write("\n\t\t|     Phone Number: ");
            int debPhoneleft = Console.CursorLeft;
            int debPhonetop = Console.CursorTop;
            Console.Write("                          |");

            Console.Write("\n\t\t|     Email: ");
            int debEmailleft = Console.CursorLeft;
            int debEmailtop = Console.CursorTop;
            Console.Write("                                 |");

            Console.Write("\n\t\t|     Address: ");
            int debAddreleft = Console.CursorLeft;
            int debAddretop = Console.CursorTop;
            Console.Write("                               |");
            Console.WriteLine("\n\t\t╙---------------------------------------------╛");
            Console.SetCursorPosition(debFNameleft, debFNametop);
            firstName = Convert.ToString(Console.ReadLine());
            myFirstName[idnum] = firstName;
            Console.SetCursorPosition(debLNameleft, debLNametop);
            lastName = Convert.ToString(Console.ReadLine());
            myLastName[idnum] = lastName;
            Console.SetCursorPosition(debPhoneleft, debPhonetop);
            phone = Convert.ToString(Console.ReadLine());
            string phoneNumber = phone;
            int debNumOfNum = 0;
            foreach (char c in phone)//count the number of character input
            {
                debNumOfNum++;
            }
            if(debNumOfNum > 10)
            {
                Console.WriteLine("\n\n\n\n\t\tPhone number is not valid");
                Console.WriteLine("\t\tPlease re-enter account information...");
                Console.ReadKey(true);
                debit();
            }
            else
            {
                myPhone[idnum] = phoneNumber;
            }//check if phone number is no more than 10;
            Console.SetCursorPosition(debEmailleft, debEmailtop);
            email = Convert.ToString(Console.ReadLine());
            if (email.Contains("@") == false || email.Contains("gmail.com") == false && email.Contains("outlook.com") == false && email.Contains("uts.edu.au") == false)
            {
  
                    Console.WriteLine("\n\n\n\t\tEmail is not valid");
                    Console.WriteLine("\t\tPlease re-enter account information...");
                    Console.ReadKey(true);
                    debit();
              
            }
            else
            {
                myEmail[idnum] = email;
            }//check if the string of email has "@" and "outlook.com" or "gmail.com" or "uts.edu.au"
            Console.SetCursorPosition(debAddreleft, debAddretop);
            address = Convert.ToString(Console.ReadLine());
            myAddress[idnum] = address;

            Console.Write("\n\n\t\tIs the information correct (y/n)?");//check if the information input correct
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("\t\tDebit account created successfully...! ");
                id = Id.generate();
                Console.WriteLine("\n\t\tYour Account ID : " + id + ", details will be provided via email");
                GetAcc(id);
                Console.WriteLine("\t\tPress any Key to Continue..");
                using (StreamWriter accData = File.CreateText($@"{id}.txt"))//put data into text file of account number
                {
                    accData.WriteLine("First Name | " + firstName);
                    accData.WriteLine("Last Name | " + lastName);
                    accData.WriteLine("Phone | " + phoneNumber);
                    accData.WriteLine("Email | " + email);
                    accData.WriteLine("Address | " + address);
                    accData.WriteLine("AccountNo | " + id);
                    accData.WriteLine("Account Type | " + accType);
                    accData.WriteLine("Balance | " + myBalance[idnum]);
                }
                //emailing to the person of account details
                StringBuilder emailBody = new StringBuilder();
                emailBody.AppendLine($@"<html><body>Dear Mr./Ms. {lastName},");
                emailBody.AppendLine("<p>Here is your Account Details</p>");
                emailBody.AppendLine($@"First Name | {firstName}<br>");
                emailBody.AppendLine($@"Last Name | {lastName}<br>");
                emailBody.AppendLine($@"Phone | {phoneNumber} <br>");
                emailBody.AppendLine($@"Email | {email} <br>");
                emailBody.AppendLine($@"Address | {address} <br>");
                emailBody.AppendLine($@"Account Type | {accType}  <br>");
                emailBody.AppendLine($@"AccountNo | {id}  <br><br>");
                emailBody.AppendLine("Regards, <br>");
                emailBody.AppendLine("Simple Bank Managent</body></html>");
                string fromMail = "bergizikrepes@gmail.com";
                string fromPassword = "epbjfjvgbiwykulw";
                MailMessage message = new MailMessage();
                message.From = new MailAddress("bergizikrepes@gmail.com");//email from
                message.To.Add(new MailAddress(email));//email send to
                message.Subject = "Bank Account Details";//email subject
                message.Body = emailBody.ToString();//email body
                message.IsBodyHtml = true;//to make body as html
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
            }
            else if (Console.ReadLine() == "n") //if the information is not correct it will restart create debit account
            {
                debit();
            }
            else
            {
                Console.WriteLine("\t\tError: Unknown command... Redirecting back to debit account creation");//if unknown input, it will restart create debit account
                Console.ReadKey();
                debit();
            }
        }
        public void credit()
        {
            string accType;
            string firstName;
            string lastName;
            string email;
            string phone;
            string address;
            Console.Clear();
            accType = "Credit";
            myAccType[idnum] = accType;
            Console.WriteLine("\t\t╒=============================================╕");//UI for Create credit account
            Console.WriteLine("\t\t|             CREATE CREDIT ACCOUNT           |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|               Enter Your Details            |");
            Console.Write("\t\t|     First Name: ");
            int creFNameleft = Console.CursorLeft;
            int creFNametop = Console.CursorTop;
            Console.Write("                            |");
            Console.Write("\n\t\t|     Last Name: ");
            int creLNameleft = Console.CursorLeft;
            int creLNametop = Console.CursorTop;
            Console.Write("                             |");
            Console.Write("\n\t\t|     Phone Number: ");
            int crePhoneleft = Console.CursorLeft;
            int crePhonetop = Console.CursorTop;
            Console.Write("                          |");
            Console.Write("\n\t\t|     Email: ");
            int creEmailleft = Console.CursorLeft;
            int creEmailtop = Console.CursorTop;
            Console.Write("                                 |");
            Console.Write("\n\t\t|     Address: ");
            int creAddreleft = Console.CursorLeft;
            int creAddretop = Console.CursorTop;
            Console.Write("                               |");
            Console.WriteLine("\n\t\t╙---------------------------------------------╛");
            Console.SetCursorPosition(creFNameleft, creFNametop);
            firstName = Convert.ToString(Console.ReadLine());
            myFirstName[idnum] = firstName;
            Console.SetCursorPosition(creLNameleft, creLNametop);
            lastName = Convert.ToString(Console.ReadLine());
            myLastName[idnum] = lastName;
            Console.SetCursorPosition(crePhoneleft, crePhonetop);
            phone = Convert.ToString(Console.ReadLine());
            string phoneNumber = phone;
            int debNumOfNum = 0;
            foreach (char c in phone)//count the number of character input
            {
                debNumOfNum++;
            }
            
            if (debNumOfNum > 10)
            {
                Console.WriteLine("\n\n\n\n\t\tPhone number is not valid");
                Console.WriteLine("\t\tPlease re-enter account information...");
                Console.ReadKey(true);
                debit();
            }
            else
            {
                myPhone[idnum] = phoneNumber;
            }//check if phone number is no more than 10;
            Console.SetCursorPosition(creEmailleft, creEmailtop);
            email = Convert.ToString(Console.ReadLine());
            if (email.Contains("@") == false || email.Contains("gmail.com") == false && email.Contains("outlook.com") == false && email.Contains("uts.edu.au") == false)
            {

                Console.WriteLine("\n\n\n\t\tEmail is not valid");
                Console.WriteLine("\t\tPlease re-enter account information...");
                Console.ReadKey(true);
                debit();

            }
            else
            {
                myEmail[idnum] = email;
            }//check if the string of email has "@" and "outlook.com" or "gmail.com" or "uts.edu.au"
            Console.SetCursorPosition(creAddreleft, creAddretop);
            address = Convert.ToString(Console.ReadLine());
            myAddress[idnum] = address;
            Console.Write("\n\n\t\tIs the information correct (y/n)?");//checks if the information input correct
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("\t\tCredit account created successfully...! ");
                id = Id.generate();
                
                Console.WriteLine("\n\t\tYour Account Id : " + id + ", details will be provided via email");
                GetAcc(id);
               
                Console.WriteLine("\t\tPress any Key to Continue..");
                using (StreamWriter accData = File.CreateText($@"{id}.txt"))//put data into text file of account number
                {
                    accData.WriteLine("First Name | " + firstName);
                    accData.WriteLine("Last Name | " + lastName);
                    accData.WriteLine("Phone | " + phoneNumber);
                    accData.WriteLine("Email | " + email);
                    accData.WriteLine("Address | " + address);
                    accData.WriteLine("AccountNo | " + id);
                    accData.WriteLine("Account Type | " + accType);
                    accData.WriteLine("Balance | " + myBalance[idnum]);
                }
                //emailing to the person of account details
                StringBuilder emailBody = new StringBuilder();
                emailBody.AppendLine($@"<html><body>Dear Mr./Ms. {lastName},");
                emailBody.AppendLine("<p>Here is your Account Details</p>");
                emailBody.AppendLine($@"First Name | {firstName}<br>");
                emailBody.AppendLine($@"Last Name | {lastName}<br>");
                emailBody.AppendLine($@"Phone | {phoneNumber} <br>");
                emailBody.AppendLine($@"Email | {email} <br>");
                emailBody.AppendLine($@"Address | {address} <br>");
                emailBody.AppendLine($@"Account Type | {accType}  <br>");
                emailBody.AppendLine($@"AccountNo | {id}  <br><br>");
                emailBody.AppendLine("Regards, <br>");
                 emailBody.AppendLine("Simple Bank Managent</body></html>");
                string fromMail = "bergizikrepes@gmail.com";
                string fromPassword = "epbjfjvgbiwykulw";
                MailMessage message = new MailMessage();
                message.From = new MailAddress("bergizikrepes@gmail.com");//email from
                message.To.Add(new MailAddress(email));//email send to
                message.Subject = "Bank Account Details";
                message.Body = emailBody.ToString();
                message.IsBodyHtml = true;//to make body as html
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
            }
            else if (Console.ReadLine() == "n")//if the information is not correct it will restart create credit account
            {
                credit();
            }
            else
            {
                Console.WriteLine("\t\tError: Unknown command... Redirecting back to credit account creation");//if unknown input, it will restart create credit account
                Console.ReadKey();
                credit();
            }
        }
        public void savings()
        {
            string accType;
            string firstName;
            string lastName;
            string email;
            string phone;
            string address;
            Console.Clear();
            accType = "Savings";
            myAccType[idnum] = accType;
            Console.WriteLine("\t\t╒=============================================╕");//UI for Create savings account
            Console.WriteLine("\t\t|             CREATE SAVINGS ACCOUNT          |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|               Enter Your Details            |");
            Console.Write("\t\t|     First Name: ");
            int savFNameleft = Console.CursorLeft;
            int savFNametop = Console.CursorTop;
            Console.Write("                            |");
            Console.Write("\n\t\t|     Last Name: ");
            int savLNameleft = Console.CursorLeft;
            int savLNametop = Console.CursorTop;
            Console.Write("                             |");
            Console.Write("\n\t\t|     Phone Number: ");
            int savPhoneleft = Console.CursorLeft;
            int savPhonetop = Console.CursorTop;
            Console.Write("                          |");
            Console.Write("\n\t\t|     Email: ");
            int savEmailleft = Console.CursorLeft;
            int savEmailtop = Console.CursorTop;
            Console.Write("                                 |");
            Console.Write("\n\t\t|     Address: ");
            int savAddreleft = Console.CursorLeft;
            int savAddretop = Console.CursorTop;
            Console.Write("                               |");
            Console.WriteLine("\n\t\t╙---------------------------------------------╛");
            Console.SetCursorPosition(savFNameleft, savFNametop);
            firstName = Convert.ToString(Console.ReadLine());
            myFirstName[idnum] = firstName;
            Console.SetCursorPosition(savLNameleft, savLNametop);
            lastName = Convert.ToString(Console.ReadLine());
            myLastName[idnum] = lastName;
            Console.SetCursorPosition(savPhoneleft, savPhonetop);
            phone = Convert.ToString(Console.ReadLine());
            string phoneNumber = phone;
            int debNumOfNum = 0;
            foreach (char c in phone)//count the number of character input
            {
                debNumOfNum++;
            }
            if (debNumOfNum > 10)
            {
                Console.WriteLine("\n\n\n\n\t\tPhone number is not valid");
                Console.WriteLine("\t\tPlease re-enter account information...");
                Console.ReadKey(true);
                debit();
            }
            else
            {
                myPhone[idnum] = phoneNumber;
            }//check if phone number is no more than 10;
            Console.SetCursorPosition(savEmailleft, savEmailtop);
            email = Convert.ToString(Console.ReadLine());
            if (email.Contains("@") == false || email.Contains("gmail.com") == false && email.Contains("outlook.com") == false && email.Contains("uts.edu.au") == false)
            {

                Console.WriteLine("\n\n\n\t\tEmail is not valid");
                Console.WriteLine("\t\tPlease re-enter account information...");
                Console.ReadKey(true);
                debit();

            }
            else
            {
                myEmail[idnum] = email;
            }//check if the string of email has "@" and "outlook.com" or "gmail.com" or "uts.edu.au"
            Console.SetCursorPosition(savAddreleft, savAddretop);
            address = Convert.ToString(Console.ReadLine());
            myAddress[idnum] = address;
            Console.Write("\n\n\t\tIs the information correct (y/n)?");//checks if the information input correct
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("\t\tSavings account created successfully...! ");
                id = Id.generate();
                Console.WriteLine("\n\t\tYour Account Id : " + id + ", details will be provided via email");
                GetAcc(id);
                Console.WriteLine("\t\tPress any Key to Continue..");
                using (StreamWriter accData = File.CreateText($@"{id}.txt"))//put data into text file of account number
                {
                    accData.WriteLine("First Name | " + firstName);
                    accData.WriteLine("Last Name | " + lastName);
                    accData.WriteLine("Phone | " + phoneNumber);
                    accData.WriteLine("Email | " + email);
                    accData.WriteLine("Address | " + address);
                    accData.WriteLine("AccountNo | " + id);
                    accData.WriteLine("Account Type | " + accType);
                    accData.WriteLine("Balance | " + myBalance[idnum]);
                }
                //send email details to the person's email
                StringBuilder emailBody = new StringBuilder();
                emailBody.AppendLine($@"<html><body>Dear Mr./Ms. {lastName},");
                emailBody.AppendLine("<p>Here is your Account Details</p>");
                emailBody.AppendLine($@"First Name | {firstName}<br>");
                emailBody.AppendLine($@"Last Name | {lastName}<br>");
                emailBody.AppendLine($@"Phone | {phoneNumber} <br>");
                emailBody.AppendLine($@"Email | {email} <br>");
                emailBody.AppendLine($@"Address | {address} <br>");
                emailBody.AppendLine($@"Account Type | {accType}  <br>");
                emailBody.AppendLine($@"AccountNo | {id}  <br><br>");
                emailBody.AppendLine("Regards, <br>");
                emailBody.AppendLine("Simple Bank Managent</body></html>");
                string fromMail = "bergizikrepes@gmail.com";
                string fromPassword = "epbjfjvgbiwykulw";
                MailMessage message = new MailMessage();
                message.From = new MailAddress("bergizikrepes@gmail.com");//email from
                message.To.Add(new MailAddress(email));//email send to
                message.Subject = "Bank Account Details";//email subject
                message.Body = emailBody.ToString();//text on email
                message.IsBodyHtml = true;//to make body as html
                var smtpClient = new SmtpClient("smtp.gmail.com") //use gmail smtp
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
            }
            else if (Console.ReadLine() == "n")//if the information is not correct it will restart create savings account
            {
                savings();
            }
            else
            {
                Console.WriteLine("\t\tError: Unknown command... Redirecting back to savings account creation");//if unknown input, it will restart create savings account
                Console.ReadKey();
                savings();
            }
        }
        public void showInfo()
        {
            Console.Clear();
            Console.WriteLine("\t\t╒=============================================╕");//UI for search account
            Console.WriteLine("\t\t|               SEARCH AN ACCOUNT             |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|                                             |");
            Console.Write("\t\t|  Enter account ID: ");
            int sAccleft = Console.CursorLeft;
            int sAcctop = Console.CursorTop;
            Console.Write("                         |");
            Console.WriteLine("\n\t\t|                                             |");
            Console.WriteLine("\t\t╙---------------------------------------------╛");

            Console.Write("\n\n\t\t╒====================================================╕");
            Console.Write("\n\t\t|                SIMPLE BANK SYSTEM                  |");
            Console.Write("\n\t\t|====================================================|");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t╙----------------------------------------------------╛");
            Console.SetCursorPosition(sAccleft, sAcctop);
            string inId = Convert.ToString(Console.ReadLine());
            int searchnumOfCharID = 0;
            foreach (char c in inId)//count the number of character input
            {
                searchnumOfCharID++;
            }
            if (searchnumOfCharID > 10)//check if ID input id is no more than 10
            {
                Console.WriteLine("\n\n\t\tError: Invalid Account Number");
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tretry (y/n)?");//if user want to rety serach account id

                string searchAccInv = Convert.ToString(Console.ReadLine());
                if (searchAccInv == "y")
                {
                    showInfo();
                }
                else if (searchAccInv == "n")
                {
                    Console.WriteLine("\t\tPress any key to return to menu..");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }
                else
                {
                    Console.WriteLine("\t\tError: Unknown command... Redirecting to menu");
                    mn.menuScrn();
                }
            }
            else
            {
                int indexNum;


                if (myId.Contains(inId))//check if id found in database
                {
                    Console.Write("\n\n\n\t\tAccount Found!");

                    indexNum = Array.IndexOf(myId, inId);

                    Console.Write("\n\t\t╒====================================================╕");//UI for show account details
                    Console.Write("\n\t\t|                   ACCOUNT DETAILS                  |");
                    Console.Write("\n\t\t|====================================================|");
                    Console.Write("\n\t\t|                                                    |");
                    Console.Write("\n\t\t|  First Name: " + myFirstName[indexNum]);
                    Console.Write("\n\t\t|  Last Name: " + myLastName[indexNum]);
                    Console.Write("\n\t\t|  Id: " + myId[indexNum]);
                    Console.Write("\n\t\t|  Acc Type: " + myAccType[indexNum]);
                    Console.Write("\n\t\t|  Balance: " + myBalance[indexNum]);
                    Console.Write("\n\t\t|  Address: " + myAddress[indexNum]);
                    Console.Write("\n\t\t|  Phone: " + myPhone[indexNum]);
                    Console.Write("\n\t\t|  Email: " + myEmail[indexNum]);
                    Console.Write("\n\t\t╙----------------------------------------------------╛");
                    Console.Write("\n\t\tCheck another account (y/n)?");//if user want to check another account
                    if (Console.ReadLine() == "y")
                    {
                        showInfo();
                    }
                    else
                    {
                        Console.Write("\t\tPress any key to return to menu..");
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\t\tAccount not found!");
                    Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tCheck another account (y/n)?");
                    if (Console.ReadLine() == "y")
                    {
                        showInfo();
                    }
                    else
                    {
                        Console.Write("\t\tPress any key to return to menu..");
                    }
                }

            }
        }
        public void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public void deposit()
        {
            Console.Clear();
            Console.WriteLine("\t\t╒=============================================╕");//UI for deposit balance account
            Console.WriteLine("\t\t|                   DEPOSIT                   |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|            ENTER ACCOUNT DETAILS            |");
            Console.WriteLine("\t\t|                                             |");
            Console.Write("\t\t|  Account ID: ");
            int depoAccleft = Console.CursorLeft;
            int depoAcctop = Console.CursorTop;
            Console.Write("                               |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t╙---------------------------------------------╛");
            Console.SetCursorPosition(depoAccleft, depoAcctop);
            string inId = Convert.ToString(Console.ReadLine());
            int depnumOfCharID = 0;
            foreach (char c in inId)//count the number of character input
            {
                depnumOfCharID++;
            }
            if (depnumOfCharID > 10)//check if account id input is no more than 10
            {
                Console.WriteLine("\n\n\n\t\tError: Invalid Account Number");
                Console.Write("\t\tretry (y/n)?");//check if the 

                string depAccInv = Convert.ToString(Console.ReadLine());
                if (depAccInv == "y")
                {
                    deposit();
                }
                else if(depAccInv == "n")
                {
                    Console.WriteLine("\t\tPress any key to return to menu..");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }
                else
                {
                    Console.WriteLine("\t\tError: Unknown command... Redirecting to menu");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }

            }
            else
            {
                int indexNum;
                if (myId.Contains(inId))//check if id found in database
                {
                    indexNum = Array.IndexOf(myId, inId);
                    Console.WriteLine("\t\t|  Your Balance is: $" + myBalance[indexNum]);
                    Console.Write("\t\t|  How much you want to deposit: $");
                    int depoleft = Console.CursorLeft;
                    int depotop = Console.CursorTop;
                    Console.Write("            |");
                    Console.SetCursorPosition(depoleft, depotop);
                    double depval = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\t\t╙---------------------------------------------╛");
                    transactions++;
                    if (myAccType[indexNum] == "Debit")
                    {
                        db.balance = myBalance[indexNum];
                        db.deposit(depval);
                        myBalance[indexNum] = db.balance;
                    }
                    else if (myAccType[indexNum] == "Credit")
                    {
                        cr.balance = myBalance[indexNum];
                        cr.deposit(depval);
                        myBalance[indexNum] = db.balance;
                    }
                    else if (myAccType[indexNum] == "Savings")
                    {
                        sv.balance = myBalance[indexNum];
                        sv.deposit(depval);
                        myBalance[indexNum] = sv.balance;
                    }
                    lineChanger($@"Balance | {myBalance[indexNum]}", $@"{id}.txt", 8);//change balance in txt file
                    //update data into balance | (after deposit)
                    using (StreamWriter accData = File.AppendText($@"{id}.txt"))
                    {
                        accData.WriteLine(DateTime.Now.ToString("M.d.yyyy") + " | Deposit | " + depval + " | " + myBalance[indexNum]);
                    }
                    //input data into account txt file (date | amount to Deposit | (balance after deposited)
                    Console.WriteLine("\t\tPress any Key to return to menu..");
                }
                else
                {
                    Console.WriteLine("\n\n\n\t\tAccount not found!");
                    Console.Write("\t\tretry (y/n)?");

                    string depAccNotFound = Convert.ToString(Console.ReadLine());
                    if (depAccNotFound == "y")
                    {
                        deposit();
                    }
                    else if(depAccNotFound == "n")
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }
                    else
                    {
                        Console.WriteLine("\t\tError: Unknown command... Redirecting to menu");
                    }
                }
            }

        }
        
        public void withdraw()
        {
            Console.Clear();
            Console.WriteLine("\t\t╒=============================================╕");//UI for withdraw balance from account
            Console.WriteLine("\t\t|                   WITHDRAW                  |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|             ENTER ACCOUNT DETAILS           |");
            Console.Write("\t\t|  Account ID: ");
            int withAccleft = Console.CursorLeft;
            int withAcctop = Console.CursorTop;
            Console.Write("                               |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t╙---------------------------------------------╛");
            Console.SetCursorPosition(withAccleft, withAcctop);
            string inId = Convert.ToString(Console.ReadLine());
            int withnumOfCharID = 0;
            foreach (char c in inId)
            {
                withnumOfCharID++;
            }
            if (withnumOfCharID > 10)
            {
                Console.WriteLine("\n\n\n\t\tError: Invalid Account Number");
                Console.Write("\t\tretry (y/n)?");

                string withAccInv = Convert.ToString(Console.ReadLine());
                if (withAccInv == "y")
                {
                    withdraw();
                }
                else if (withAccInv == "n")
                {
                    Console.WriteLine("\t\tPress any key to return to menu..");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }
                else
                {
                    Console.WriteLine("\t\tError: Unknown command... Redirecting to menu");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }

            }
            else
            {
                int indexNum;

                if (myId.Contains(inId))//check if id found in database
                {
                    indexNum = Array.IndexOf(myId, inId);
                    Console.WriteLine("\t\t|  Your Balance is: $" + myBalance[indexNum]);
                    Console.Write("\t\t|  How much you want to withdraw: $");
                    int withleft = Console.CursorLeft;
                    int withtop = Console.CursorTop;
                    Console.Write("           |");
                    Console.SetCursorPosition(withleft, withtop);
                    double depval = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\t\t╙---------------------------------------------╛");
                    transactions++;
                    if (myAccType[indexNum] == "Debit")
                    {
                        db.balance = myBalance[indexNum];
                        db.withdraw(depval);
                        myBalance[indexNum] = db.balance;
                    }
                    else if (myAccType[indexNum] == "Credit")
                    {
                        cr.balance = myBalance[indexNum];
                        cr.withdraw(depval);
                        myBalance[indexNum] = cr.balance;
                    }
                    else if (myAccType[indexNum] == "Savings")
                    {
                        sv.balance = myBalance[indexNum];
                        sv.withdraw(depval);
                        myBalance[indexNum] = sv.balance;
                    }
                    lineChanger($@"Balance | {myBalance[indexNum]}", $@"{id}.txt", 8);//change balance in txt file
                    //update data into balance | (after withdraw)
                    using (StreamWriter accData = File.AppendText($@"{id}.txt"))
                    {
                        accData.WriteLine(DateTime.Now.ToString("M.d.yyyy") + " | Withdraw | " + depval + " | " + myBalance[indexNum]);
                    }
                    //input data into account txt file (date | amount of Withdraw | (balance after Withdraw)
                    Console.WriteLine("\t\tPress any Key to return to menu..");
                }
                else
                {
                    Console.WriteLine("\n\n\n\t\tAccount not found!");
                    Console.Write("\t\tretry (y/n)?");

                    string withAccNotFound = Convert.ToString(Console.ReadLine());
                    if (withAccNotFound == "y")
                    {
                        withdraw();
                    }
                    else
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }
                }
            }

        }
        public void statement()
        {
            Console.Clear();
            Console.WriteLine("\t\t╒=============================================╕");//UI for account statement
            Console.WriteLine("\t\t|              ACCOUNT STATEMENT              |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|              ENTER THE DETAILS              |");
            Console.Write("\t\t|  Account ID: ");
            int staAccleft = Console.CursorLeft;
            int staAcctop = Console.CursorTop;
            Console.Write("                               |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t╙---------------------------------------------╛");

            Console.Write("\n\n\t\t╒====================================================╕");
            Console.Write("\n\t\t|                SIMPLE BANK SYSTEM                  |");
            Console.Write("\n\t\t|====================================================|");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t╙----------------------------------------------------╛");
            Console.SetCursorPosition(staAccleft, staAcctop);
            string inId = Convert.ToString(Console.ReadLine());
            int statenumOfCharID = 0;//check if id input is no more than 10
            foreach (char c in inId)
            {
                statenumOfCharID++;
            }
            if (statenumOfCharID > 10)
            {
                Console.WriteLine("\t\t|  Error: Invalid Account Number");
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tretry (y/n)?");

                string stateAccInv = Convert.ToString(Console.ReadLine());
                if (stateAccInv == "y")
                {
                    statement();
                }
                else
                {
                    Console.WriteLine("\t\tPress any key to return to menu..");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }
            }
            else
            {
                int indexNum;
                if (myId.Contains(inId))//check id in database
                {
                    indexNum = Array.IndexOf(myId, inId);
                    Console.WriteLine("\t\t|  Account has been found!");
                    Console.Write("\t\t|  Are you a robot? (y/n)");//check if user is not robot 
                    int rbtEmailleft = Console.CursorLeft;
                    int rbtEmailtop = Console.CursorTop;
                    Console.SetCursorPosition(rbtEmailleft, rbtEmailtop);
                    string robot = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\t\t╙---------------------------------------------╛");
                    if (robot == "y")
                    {
                        statement();
                    }
                    else if (robot == "n")
                    {
                        //for show the account
                        Console.Write("\n\t\t╒====================================================╕");
                        Console.Write("\n\t\t|                   ACCOUNT DETAILS                  |");
                        Console.Write("\n\t\t|====================================================|");
                        Console.Write("\n\t\t|                                                    |");
                        Console.Write("\n\t\t|  First Name: " + myFirstName[indexNum]);
                        Console.Write("\n\t\t|  Last Name: " + myLastName[indexNum]);
                        Console.Write("\n\t\t|  Id: " + myId[indexNum]);
                        Console.Write("\n\t\t|  Acc Type: " + myAccType[indexNum]);
                        Console.Write("\n\t\t|  Balance: " + myBalance[indexNum]);
                        Console.Write("\n\t\t|  Address: " + myAddress[indexNum]);
                        Console.Write("\n\t\t|  Phone: " + myPhone[indexNum]);
                        Console.Write("\n\t\t|  Email: " + myEmail[indexNum]);
                        Console.Write("\n\t\t╙----------------------------------------------------╛");
                        Console.Write("\n\n\t\tEmail Statement (y/n)?");
                        int emailstaleft = Console.CursorLeft;
                        int emailstatop = Console.CursorTop;
                        Console.SetCursorPosition(emailstaleft, emailstatop);
                        string emailsta = Convert.ToString(Console.ReadLine());

                        if (emailsta == "y")
                        {
                            var lines = File.ReadAllLines($@"{id}.txt ").Reverse().Take(5);

                         
                            //sent email using html 
                            StringBuilder emailBody = new StringBuilder();
                            emailBody.AppendLine($@"<html><body>Dear Mr./Ms.{myLastName[indexNum]},");
                            emailBody.AppendLine("<p>Here is your Account Details</p>");
                            emailBody.AppendLine($@"First Name | {myFirstName[indexNum]}<br>");
                            emailBody.AppendLine($@"Last Name | {myLastName[indexNum]}<br>");
                            emailBody.AppendLine($@"Phone | {myPhone[indexNum]} <br>");
                            emailBody.AppendLine($@"Email | {myEmail[indexNum]} <br>");
                            emailBody.AppendLine($@"Address | {myAddress[indexNum]} <br>");
                            emailBody.AppendLine($@"Account Type | {myAccType[indexNum]}  <br>");
                            emailBody.AppendLine($@"AccountNo | {myId[indexNum]}  <br>");
                            emailBody.AppendLine($@"Balance | {myBalance[indexNum]} <br>");
                            emailBody.AppendLine("<br>");
                            emailBody.AppendLine("Here is your last 5 transactions  <br>");
                            foreach (string line in lines) //get every line in transaction in account.txt file
                            {
                                emailBody.AppendLine($@"{line}  <br>");
                            }
                            emailBody.AppendLine("Regards, <br>");
                            emailBody.AppendLine("Simple Bank Managent</p></body></html>");
                            string fromMail = "bergizikrepes@gmail.com";
                            string fromPassword = "epbjfjvgbiwykulw";
                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("bergizikrepes@gmail.com");//email from
                            message.To.Add(new MailAddress(myEmail[indexNum]));//email send to
                            message.Subject = "Bank Account Statement";//subject of email
                            message.Body = emailBody.ToString();//the text on email
                            message.IsBodyHtml = true;//to make body as html
                            var smtpClient = new SmtpClient("smtp.gmail.com")//get gmail API
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromMail, fromPassword),
                                EnableSsl = true,
                            };
                            smtpClient.Send(message);
                            Console.WriteLine("\n\t\tStatement has been sent to email sucessfully..");
                            Console.WriteLine("\t\tPress any key to return to menu..");
                        }
                        else if (emailsta == "n")
                        {
                            Console.WriteLine("\t\tPress any key to return to menu..");
                        }
                        else
                        {
                            Console.WriteLine("\t\tinvalid input... Redirecting back to find account statement");
                            Console.ReadKey();
                            statement();
                        }
                    }
                    else
                    {
                        statement();
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tAccount not found!");
                    Console.Write("\t\tretry (y/n)?");

                    string withAccNotFound = Convert.ToString(Console.ReadLine());
                    if (withAccNotFound == "y")
                    {
                        statement();
                    }
                    else if (withAccNotFound == "n")
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }
                    else
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }

                }
            }
        }
        public void delete()
        {
            Console.Clear();
            Console.WriteLine("\t\t╒=============================================╕");//UI for delete account
            Console.WriteLine("\t\t|              DELETE AN ACCOUNT              |");
            Console.WriteLine("\t\t|=============================================|");
            Console.WriteLine("\t\t|              ENTER THE DETAILS              |");
            Console.Write("\t\t|  Account ID: ");
            int delAccleft = Console.CursorLeft;
            int delAcctop = Console.CursorTop;
            Console.Write("                               |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t|                                             |");
            Console.Write("\n\t\t╙---------------------------------------------╛");

            Console.Write("\n\n\t\t╒====================================================╕");
            Console.Write("\n\t\t|                SIMPLE BANK SYSTEM                  |");
            Console.Write("\n\t\t|====================================================|");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t|                                                    |");
            Console.Write("\n\t\t╙----------------------------------------------------╛");
            Console.SetCursorPosition(delAccleft, delAcctop);
            string inId = Convert.ToString(Console.ReadLine());
            int delnumOfCharID = 0;
            foreach (char c in inId)//count account id input
            {
                delnumOfCharID++;
            }
            if (delnumOfCharID > 10)//check if id input is no more than 10
            {
                Console.WriteLine("\t\t|  Error: Invalid Account Number");
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tretry (y/n)?");

                string delAccInv = Convert.ToString(Console.ReadLine());
                if (delAccInv == "y")
                {
                    delete();
                }
                else if (delAccInv == "n")
                {
                    Console.WriteLine("\t\tPress any key to return to menu..");
                    Console.ReadKey(true);
                    mn.menuScrn();
                }
                else
                {
                    delete();
                }
            }
            else
            {
                int indexNum;
                if (myId.Contains(inId))//check id in database
                {
                    indexNum = Array.IndexOf(myId, inId);
                    Console.WriteLine("\t\t|  Account has been found!");
                    Console.Write("\t\t|  Are you a robot? (y/n)");//check if user is not robot
                    int withleft = Console.CursorLeft;
                    int withtop = Console.CursorTop;
                    Console.SetCursorPosition(withleft, withtop);
                    string robot = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("\t\t╙---------------------------------------------╛");
                    if (robot == "y")
                    {
                        delete();
                    }
                    else if (robot == "n")
                    {
                        //for show the account and check if the user really want to delete the account
                        Console.Write("\n\t\t╒====================================================╕");
                        Console.Write("\n\t\t|                   ACCOUNT DETAILS                  |");
                        Console.Write("\n\t\t|====================================================|");
                        Console.Write("\n\t\t|                                                    |");
                        Console.Write("\n\t\t|  First Name: " + myFirstName[indexNum]);
                        Console.Write("\n\t\t|  Last Name: " + myLastName[indexNum]);
                        Console.Write("\n\t\t|  Id: " + myId[indexNum]);
                        Console.Write("\n\t\t|  Acc Type: " + myAccType[indexNum]);
                        Console.Write("\n\t\t|  Balance: " + myBalance[indexNum]);
                        Console.Write("\n\t\t|  Address: " + myAddress[indexNum]);
                        Console.Write("\n\t\t|  Phone: " + myPhone[indexNum]);
                        Console.Write("\n\t\t|  Email: " + myEmail[indexNum]);
                        Console.Write("\n\t\t╙----------------------------------------------------╛");
                        Console.Write("\n\n\t\tAre you sure want to delete the account (y/n)?");//check if user really want to delete account
                        int delaccleft = Console.CursorLeft;
                        int delacctop = Console.CursorTop;
                        Console.SetCursorPosition(delaccleft, delacctop);
                        string delAccCon = Convert.ToString(Console.ReadLine());
                        if (delAccCon == "y")
                        {
                            File.Delete($@"{myId[indexNum]}.txt");
                            myId = myId.Skip(1).ToArray();
                            Console.WriteLine("\n\t\tAccount has been deleted");
                            Console.WriteLine("\t\tPress any key to return to menu..");
                        }
                        else if(delAccCon == "n")
                        {
                            Console.WriteLine("\t\tPress any key to return to menu..");
                        }
                        else
                        {
                            delete();
                        }

                    }
                    else
                    {
                        delete();
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tAccount not found!");
                    Console.Write("\t\tretry (y/n)?");
                    string withAccNotFound = Convert.ToString(Console.ReadLine());
                    if (withAccNotFound == "y")
                    {
                        delete();
                    }
                    else if (withAccNotFound == "n")
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }
                    else
                    {
                        Console.WriteLine("\t\tPress any key to return to menu..");
                    }
                }
            }
        }
    }
}

