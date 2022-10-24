using System;
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
        public void reports()
        {
            Reports reportsMenu = new Reports();
            string choice = "";
            while (choice != "x")
            {
                reportsMenu.reportsMenu();
                choice = Console.ReadLine().ToUpper().Trim();
                if (choice == "1")
                {
                    dailySales("Daily sales reports\n");
                }
                else if (choice == "2")
                {
                    productInventory();

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

        static void dailySales(string message) //Date | Grand Total
        {
            Console.Clear();
            Console.WriteLine(message);                     //Display Daily sales reports.
            Inventory check = new Inventory();              //Initalize Inventory Class.

            string path = "DailySales.txt";                 //Indicate text file name.
            string[][] dailySales = check.transfer(path);     //Transfer text files into array.

            Console.WriteLine("Date\t\tGrand total\n");
            for (int i = 0; i < dailySales.Length; i++)
            {
                Console.Write("{0}\t{1}\n", dailySales[i][0], dailySales[i][1]);

            }
            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            /*foreach (var line in dailySales)                //Display daily sales.
            {
                Console.WriteLine(line);

            }*/

        }
        static void productInventory()//Category | Product
        {
            Console.WriteLine("Inventory of Sold Items");

        }
        static void returns()//Return Date | Category | Product
        {
            Console.WriteLine("List of Return Items");

        }

        private void reportsMenu()
        {
            Console.Write("1 - Daily sales reports" +
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