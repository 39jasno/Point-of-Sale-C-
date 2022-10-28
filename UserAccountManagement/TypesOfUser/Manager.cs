using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Group11_Machine_Problem
{
    class Manager : User
    {
        public Manager(string username)
        {
            this.Username = username;
        }


        //display manager menu and does coresponding actions based on user choice
        public void DisplayMenu()
        {
            Checker check = new Checker();

            SetUserInfo();

            string choice;
            do
            {
                if (check.IsAccountActive(Username))
                {
                    Reports initReport = new Reports();
                    ProdManage initProd = new ProdManage();
                    OrderManage initOrder = new OrderManage();

                    Console.WriteLine("Manager Menu");
                    Console.WriteLine("\n 1 - Product Management " +
                        "\n 2 - Order Management  " +
                        "\n 3 - Reports Management" +
                        "\n 4 - User Account Management" +
                        "\n 5 - Add a New User" +
                        "\n 6 - Logout");
                    Console.Write("\nEnter choice: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": Console.Clear(); initProd.Main(); break;
                        case "2": Console.Clear(); initOrder.Main(); break;
                        case "3": Console.Clear(); initReport.Main(); break;
                        case "4": Console.Clear(); ManageUserAccount("Manager User Management Menu\n"); break;
                        case "5": Console.Clear(); CreateUser(); break;
                        case "6": Console.WriteLine("Logging out..."); Thread.Sleep(800); Console.Clear(); break;

                        default: Console.WriteLine("Invalid Input: Select a choice from the options!"); Thread.Sleep(800); Console.Clear(); break;
                    }
                }
                else
                {
                    Console.WriteLine("Logging out..."); Thread.Sleep(800); Console.Clear(); choice = "6";
                }
            } while (choice != "6");
        }
    }
}

