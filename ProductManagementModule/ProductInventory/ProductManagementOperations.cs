using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.FileCheck;

namespace Group11_Machine_Problem
{
    class ProductManagementOperations
    {
        public void Write(string path)
        {
            Console.Clear();
            Inventory check = new Inventory();
            ProductValidation validate = new ProductValidation();
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
        public class keyboardPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search for the ID to update
            public void FindUpdate(string path)
            {
                Console.Clear();
                ProductValidation codeValidate = new ProductValidation();
                int keybUp = codeValidate.NumberLengthRequired("Enter code to update Price: ", 5);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream(path, FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] lineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    lineContent = paytonLine.Split('|');
                    if (lineContent[0] == searchKeyb)
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = lineContent[2];
                    PUpdate(path);
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                    Console.Clear();
                }
            }


            //Overwrite Price data
            private void PUpdate(string path)
            {
                ProductManagementOperations display = new ProductManagementOperations();
                ProductValidation keybValidate = new ProductValidation();
                Console.WriteLine();
                double newKeybPrice = keybValidate.DoubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newKeybPrice);

                FileStream paytonStm = new FileStream(path, FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                Console.Clear();
                Console.WriteLine("Price updated\n\n");
                display.Read(path);
                //StreamWriter paytonWriter = new StreamWriter("KeyboardData.txt");
                //paytonWriter.Write(newContent);
                //paytonWriter.Close();

                
            }
        }
        /*
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
        */
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
/*
 * public class keyboardPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;
            
            //Search for the ID to update
            public void keybFindUpdate()
            {
                validation codeValidate = new validation();
                int keybUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1,5);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream(path, FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] keyboardLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    keyboardLineContent = paytonLine.Split('|');
                    if (keyboardLineContent[0] == searchKeyb)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = keyboardLineContent[2];
                    keybPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite Price data
            private void keybPUpdate()
            {

                validation keybValidate = new validation();
                Console.WriteLine();
                double newKeybPrice = keybValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newKeybPrice);

                FileStream paytonStm = new FileStream(path, FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("KeyboardData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }
*/