using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Group11_Machine_Problem
{
    public class Reports
    {
        public void Main()
        {
            Reports reportsMenu = new Reports();
            ReportsOperations methods = new ReportsOperations();

            string choice = "";
            while (choice != "x")
            {
                reportsMenu.reportsMenu();
                choice = Console.ReadLine().ToUpper().Trim();
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
                else if (choice == "X")
                {
                    break;
                }
            }
        }
        private void reportsMenu()
        {
            Console.Write("1 - Daily sales reports" +
                "\n2 - Inventory of Sold Items" +
                "\n3 - List of Return Items" +
                "\nX - Exit" +
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