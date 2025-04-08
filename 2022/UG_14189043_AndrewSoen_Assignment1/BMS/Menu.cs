using System;

namespace BMS
{
    class Menu
    {
        public void menuScrn()
        {
            String input;
            DOB dob = new DOB();
            IDGenerator id = new IDGenerator();
            Credit cr = new Credit();
            Debit db = new Debit();
            Savings sv = new Savings();
            Bank bn = new Bank();
            Login lgn = new Login();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t╒===================================╕");
                Console.WriteLine("\t\t|  WELCOME TO SIMPLE BANKING SYSTEM |");
                Console.WriteLine("\t\t|===================================|");
                Console.WriteLine("\t\t|   What you want to do:            |");
                Console.WriteLine("\t\t|   1. Create new account           |");
                Console.WriteLine("\t\t|   2. Show account information     |");
                Console.WriteLine("\t\t|   3. Deposit from account         |");
                Console.WriteLine("\t\t|   4. Withdraw from account        |");
                Console.WriteLine("\t\t|   5. A/C Statement                |");
                Console.WriteLine("\t\t|   6. Delete Account               |");
                Console.WriteLine("\t\t|   7. Logout                       |");
                Console.WriteLine("\t\t|   8. Logout and Exit              |");
                Console.WriteLine("\t\t|===================================|");
                Console.Write("\t\t| Enter your choice (1-8): ");
                int ChoiceCursorX = Console.CursorLeft; 
                int ChoiceCursorY = Console.CursorTop;
                Console.Write("         |");
                Console.Write("\n\t\t╙-----------------------------------╛");
                Console.SetCursorPosition(ChoiceCursorX, ChoiceCursorY);
                
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);
                

                if (input == "1")
                {
                    bn.create_account();//method to create account
                }
                else if (input == "2")
                { 
                    bn.showInfo();//method to show account information
                }
                else if (input == "3")
                {
                    bn.deposit();//method to deposit balance into account
                }
                else if (input == "4")
                { 
                    bn.withdraw();//method to withdraw balance into account
                }
                else if (input == "5")
                {
                    bn.statement();//method to show account statement
                }
                else if (input == "6")
                {
                    bn.delete();//method to delete account
                }
                else if (input == "7")
                {
                    lgn.loginScrn();//method to be back at login screen
                }
                else if (input == "8")
                {
                    Environment.Exit(0); //stop the program
                }
                else
                {
                    Console.WriteLine("\n\n\t\t invalid choice... Press any key to re-enter");//all other input will be invalid choice as there were no choice in menu
                    Console.ReadKey(true);
                    menuScrn();
                }
                Console.ReadKey();


            }

        }

    }
}
    
