using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group11_Machine_Problem
{
    public class Reports
    {
        public void reports()
        {
            Reports mainMenu = new Reports();
            string choice = "";
            while (choice != "x")
            {
                mainMenu.reportsMenu();
                choice = Console.ReadLine().ToUpper();
                if (choice == "1")
                {
                    dailySales();
                }
                else if (choice == "2")
                {
                    inventory();

                }
                else if (choice == "3")
                {
                    returns();

                }
                else if (choice == "X")
                {
                    break;
                }
            }
            
        }

        static void dailySales()
        {
            Console.WriteLine("Daily sales reports");

        }
        static void inventory()
        {
            Console.WriteLine("Inventory of Sold Items");

        }
        static void returns()
        {
            Console.WriteLine("List of Return Items");

        }

        private void reportsMenu()
        {
            Console.Write("\n1 - Daily sales reports" +
                "\n2 - Inventory of Sold Items" +
                "\n3 - List of Return Items"+
                "\nX - Exit"+
                "\n\nEnter your choicec: ");
        }
    }

    
}

/*
- Daily Sales with grand total
- Sales with Specific Dates
- Inventory of Sold Item
- List of Return Item for specific date
 */