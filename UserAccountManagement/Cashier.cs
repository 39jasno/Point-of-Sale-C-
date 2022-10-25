﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Group11_Machine_Problem
{
    class Cashier : User
    {
        public Cashier(string username)
        {
            this.username = username;
        }


        //display cashier menu then does corresposding options based on user choice
        public void DisplayMenu()
        {
            string choice = "0";

            Checker check = new Checker();

            SetUserInfo();

            do
            {
                if (check.IsAccountActive(username))
                {
                    OrderManage initOrder = new OrderManage();

                    Console.WriteLine("Cashier Menu");
                    Console.WriteLine("\nPlease select an option from the menu:" +
                        "\n 1 - Order Management" +
                        "\n 2 - Returns Management" +
                        "\n 3 - Log out ");
                    Console.Write("\nEnter choice: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": Console.Clear(); initOrder.Main() ; break;
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
