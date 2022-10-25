using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ReportsManagementModule;

namespace Group11_Machine_Problem
{
    class ReportsOperations
    {
        public void dailySales(string message)                                      //Date | Grand Total
        {

            Console.Clear();
            Console.WriteLine(message);                                             //Display Daily sales reports.
            Inventory check = new Inventory();                                      //Initalize Inventory Class.
            ReportsOperations exit = new ReportsOperations();

            string path = @".\Reports\DailySales.txt";
            bool found = check.checkInfo(path);
            if (found == true)
            {
                string[][] dailySales = check.transfer(path);                           //Transfer text files into a jagged array.

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');                                    //Split the array
                    dailySales[counter] = new string[2] { info[0], info[1] };
                    counter++;
                }

                string title = String.Format("{0,-10}{1,-10}", "Date", "Grand Total");
                Console.WriteLine(title);

                for (int i = 0; i < dailySales.Length; i++)                             //Display daily sales
                {
                    string format = String.Format("{0,-10}{1,-10}", dailySales[i][0], dailySales[i][1]);
                    Console.WriteLine(format);

                }
                exit.operationsExit();
            }
            

        }
        public void productInventory(string message)                                //Category | Product
        {
            Console.Clear();
            Console.WriteLine(message);                                             //Inventory of Sold Items
            Inventory check = new Inventory();
            ReportsOperations exit = new ReportsOperations();

            string path = @".\Reports\ProductSold.txt";
            bool found = check.checkInfo(path);
            if (found == true)
            {
                string[][] productInv = check.transfer(path);                           //Transfer text file into a jagged array

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');                                    //Split into two and puting its elements into the array
                    productInv[counter] = new string[2] { info[0], info[1] };
                    counter++;
                }

                string title = String.Format("{0,-10}{1,-10}", "Category", "Product");
                Console.WriteLine(title);

                for (int i = 0; i < productInv.Length; i++)                             //Display product inventory
                {
                    string format = String.Format("{0,-10}{1,-10}", productInv[i][0], productInv[i][1]);
                    Console.WriteLine(format);

                }
                exit.operationsExit();
            }

        }
        public void returns(string message)                                         //Return Date | Category | Product
        {
            Console.Clear();
            Console.WriteLine(message);
            Inventory check = new Inventory();
            ReportsOperations exit = new ReportsOperations();

            string path = @".\Reports\ItemReturn.txt";
            bool found = check.checkInfo(path);
            if (found == true)
            {
                string[][] returnsInv = check.transfer(path);

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');
                    returnsInv[counter] = new string[3] { info[0], info[1], info[2] };
                    counter++;
                }

                string title = String.Format("{0,-15}{1,-15}{2,-15}", "Return Date", "Category", "Product");
                Console.WriteLine(title);

                for (int i = 0; i < returnsInv.Length; i++)
                {
                    string format = String.Format("{0,-15}{1,-15}{2,-15}", returnsInv[i][0], returnsInv[i][1], returnsInv[i][2]);
                    Console.WriteLine(format);

                }
                exit.operationsExit();
            }
           

        }

        private void operationsExit()
        {
            Console.WriteLine("\n\nPress any key to go back...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
