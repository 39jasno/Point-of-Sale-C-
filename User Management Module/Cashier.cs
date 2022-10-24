using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MP
{
    class Cashier : User
    {
        public Cashier(string username)
        {
            this.username = username;
        }



        public void DisplayMenu()
        {
            string choice = "0";

            Checker check = new Checker();

            SetUserInfo();

            do
            {
                if (check.IsAccountActive(username))
                {
                    Console.WriteLine("Cashier Menu");
                    Console.WriteLine("\nPlease select an option from the menu:\n 1 - Manage your account \n 2 - {option 2}  \n 3 - Log out ");
                    Console.Write("\nEnter choice: ");
                    string userChoice = Console.ReadLine();
                    choice = userChoice;

                    switch (choice)
                    {
                        case "1": Console.Clear(); ManageUserAccount("Cashier User Management Menu\n"); break;
                        case "2": break;
                        case "3": Console.WriteLine("Logging out..."); Thread.Sleep(800); Console.Clear(); break;
                        default: Console.WriteLine("Invalid Input: Select a choice from the options!"); Thread.Sleep(800); Console.Clear(); break;
                    }
                }
                else
                {
                    Console.WriteLine("Logging out..."); Thread.Sleep(800); Console.Clear(); choice = "3";
                }
            } while (choice != "3");
        }
    }
}
