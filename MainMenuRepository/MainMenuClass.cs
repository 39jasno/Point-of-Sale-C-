﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group11_Machine_Problem.MainMenuRepository
{
    class posMenu
    {
        public void adminMainMenu()
        {
            Console.Write("1 - Product management" + //Create prod info, update price, search for product
                "\n2 - Order management" + //Create order info, update order,settle bill
                "\n3 - Reports" + //Daily sale with grand total, Sales with specific date, Inventory of sold item, List of return with date, Return module
                "\n4 - User account management" + //Create new user account, Change password, Activate/Deactivate,Expiration date of account
                "\nX - Exit" +
                "\n\nEnter your choice: ");
        }
        public void employeeMainMenu()
        {
            Console.Write("1 - Order management" + //Only to make order and reports
                "\n2 - Exit" +
                "\n\nEnter your choice: ");
        }
    }
}
