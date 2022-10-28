using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.FileCheck;

namespace Group11_Machine_Problem
{
    class ReportsOperations
    {
        public void dailySales(string message)                                    
        {

            Console.Clear();
            Console.WriteLine(message);                                
            
            Inventory check = new Inventory();                                     
            ReportsOperations exit = new ReportsOperations();

            string path = "dailySales.txt";
            bool found = check.CheckInfo(path);

            if (found == true)
            {
                string[][] dailySales = check.Transfer(path);                          

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');                                   
                    dailySales[counter] = new string[2] { info[0], info[1] };
                    counter++;
                }

                string title = String.Format("{0,-10}{1,-10}\n", "Date", "Grand Total");
                Console.WriteLine(title);

                for (int i = 0; i < dailySales.Length; i++)                             
                {
                    string format = String.Format("{0,-10}{1,-10}", dailySales[i][0], dailySales[i][1]);
                    Console.WriteLine(format);

                }
                exit.operationsExit();
            }
            

        }
        public void productInventory(string message)                               
        {
            Console.Clear();
            Console.WriteLine(message);                                           
            Inventory check = new Inventory();
            ReportsOperations exit = new ReportsOperations();

            string path = "productSales.txt";
            bool found = check.CheckInfo(path);
            if (found == true)
            {
                string[][] productInv = check.Transfer(path);                          

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');                                    
                    productInv[counter] = new string[2] { info[0], info[1] };
                    counter++;
                }

                string title = String.Format("{0,-10}{1,-10}\n", "Category", "Product");
                Console.WriteLine(title);

                for (int i = 0; i < productInv.Length; i++)               
                {
                    string format = String.Format("{0,-10}{1,-10}", productInv[i][0], productInv[i][1]);
                    Console.WriteLine(format);

                }
                exit.operationsExit();
            }

        }
        public void returns(string message)                                  
        {
            Console.Clear();
            Console.WriteLine(message);
            Inventory check = new Inventory();
            ReportsOperations exit = new ReportsOperations();

            string path = "ItemReturn.txt";
            bool found = check.CheckInfo(path);
            if (found == true)
            {
                string[][] returnsInv = check.Transfer(path);

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
