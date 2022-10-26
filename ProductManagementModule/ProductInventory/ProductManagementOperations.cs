using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;
using Group11_Machine_Problem.ReportsManagementModule;

namespace Group11_Machine_Problem
{
    class ProductManagementOperations
    {
        public void Write(string path)
        {
            Console.Clear();
            Inventory check = new Inventory();
            ProductManagementModule.Validation validate = new ProductManagementModule.Validation();
            Console.WriteLine("Add product\n");
            int code = validate.NumberLengthRequired("Enter Product ID: ", 5);
            string name = validate.InputString("\nEnter Product Name: ");
            double price = validate.DoubleInput("\nEnter Product Price: ");
            int stock = validate.NumbersRequired("\nEnter Product Stock: ");


            Data write = new Data();
            write.Add(path, code, name, price, stock);
        }

        public void Read(string path)
        {
            Console.Clear();
            ProductManagementOperations transfer = new ProductManagementOperations();
            Inventory check = new Inventory();

            bool found = check.CheckInfo(path);
            if (found == true)
            {
                string[][] productInfo = transfer.TextArray(path);

                string title = String.Format("{0,-15}{1,-25}{2,-10}{3,-10}{4,-10}\n", "Product No", "Product Name", "Price", "Qty", "Sold");
                Console.WriteLine(title);

                for (int i = 0; i < productInfo.Length; i++)
                {
                    string format = String.Format("{0,-15}{1,-25}{2,-10}{3,-10}{4,-10}", productInfo[i][0], productInfo[i][1], productInfo[i][2], productInfo[i][3], productInfo[i][4]);
                    Console.WriteLine(format);

                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void Search(string path)
        {
            Console.Clear();
            ProductManagementOperations transfer = new ProductManagementOperations();
            Inventory check = new Inventory();

            bool found = check.CheckInfo(path);
            bool searchtrue = false;

            Console.Write("Enter Product Code: ");
            string search = Console.ReadLine();

            if (found == true)
            {
                string[][] productInfo = transfer.TextArray(path);
                for (int i = 0; i < productInfo.Length; i++)
                {
                    if (productInfo[i][0] == search)
                    {
                        Console.Clear();

                        string title = String.Format("{0,-15}{1,-25}{2,-10}{3,-10}{4,-10}\n", "Product No", "Product Name", "Price", "Qty", "Sold");
                        string format = String.Format("{0,-15}{1,-25}{2,-10}{3,-10}{4,-10}", productInfo[i][0], productInfo[i][1], productInfo[i][2], productInfo[i][3], productInfo[i][4]);
                        
                        Console.WriteLine(title + "\n" + format);

                        searchtrue = true;
                        break;
                    }
                }
                if (searchtrue == false)
                {
                    Console.Clear();
                    Console.WriteLine("Product does not exist.");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }
        private string[][] TextArray(string path)
        {
            Inventory check = new Inventory();
            string[][] productInfo = check.Transfer(path);
            int counter = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                string[] info = line.Split('|');
                productInfo[counter] = new string[5] { info[0], info[1], info[2], info[3], info[4] };
                counter++;

            }
            return productInfo;
        }

        public class PriceUpdate
        {
            public void Update(string path)
            {
                Console.Clear();
                ProductManagementOperations transfer = new ProductManagementOperations();
                ProductManagementModule.Validation validate = new ProductManagementModule.Validation();
                Inventory check = new Inventory();

                Console.Write("Enter Product Code: ");
                string search = Console.ReadLine();

                bool found = check.CheckInfo(path);
                bool searchtrue = false;
                if (found == true)
                {
                    string[][] vs = transfer.TextArray(path);
                    string[][] productInfo = vs;
                    for (int i = 0; i < productInfo.Length; i++)
                    {
                        if (productInfo[i][0] == search)
                        {
                            Console.Clear();
                            int newPrice = validate.NumbersRequired("Enter product's new price: ");
                            searchtrue = true;
                            break;
                        }
                    }
                    if (searchtrue == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Product does not exist.");
                    }
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            }
        }
        class Data
        {
            public void Add(string path,int code, string name, double price, int stock)
            {

                Console.Clear();
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(code + "|" + name + "|" + price + "|" + stock + "|" + 0);
                    writer.Close();
                }
            }
        }
    }
}