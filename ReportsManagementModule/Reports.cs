﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ReportsManagementModule;

namespace Group11_Machine_Problem
{
    public class Reports
    {
        public void Main()
        {
            Reports reportsMenu = new Reports();
            ReportsOperations methods = new ReportsOperations();
            InitializeSales init = new InitializeSales();

            string choice = "";
            while (choice != "x")
            {
                init.Initialize();
                reportsMenu.reportsMenu();
                choice = Console.ReadLine().Trim();
                if (choice == "1")
                {
                    methods.dailySales("Daily sales reports\n");
                }
                else if (choice == "2")
                {
                    methods.productInventory("Inventory of Sold Items\n");

                }
                else if (choice == "3")
                {
                    methods.returns("List of Return Items\n");

                }
                else if (choice == "4")
                {
                    Console.Clear();
                    break;
                }
            }
        }
        private void reportsMenu()
        {
            Console.Write("Reports Management\n" +
                "\n1 - Daily sales reports" +
                "\n2 - Inventory of Sold Items" +
                "\n3 - List of Return Items" +
                "\n4 - Exit" +
                "\n\nEnter your choicec: ");
        }


    }

    
}
