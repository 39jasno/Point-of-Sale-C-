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
        public void write(string path)
        {
            Console.Clear();
            validation validate = new validation();
            Console.WriteLine("Add product\n");
            int code = validate.numberLengthRequired("Enter Product ID: ", 5);
            string name = validate.InputString("\nEnter Product Name: ");
            double price = validate.doubleInput("\nEnter Product Price: ");
            int stock = validate.numbersRequired("\nEnter Product Stock: ");
            //int sold = validate.numbersRequired("\nEnter Product Sold: ");        //sold should not be added. Only update on order information

            Data write = new Data();
            write.add(path, code, name, price, stock);
        }

        //Read and Print Product informations
        public void read(string path)
        {
            Console.Clear();
            ProductManagementOperations transfer = new ProductManagementOperations();
            Inventory check = new Inventory();
            bool found = check.checkInfo(path);
            if (found == true)
            {
                string[][] productInfo = transfer.textArray(path);
                Console.WriteLine("Product No - Product Name - Price - Qty - Sold\n");
                for (int i = 0; i < productInfo.Length; i++)
                {
                    Console.Write("{0} - {1} - {2} - {3} - {4}\n", productInfo[i][0], productInfo[i][1], productInfo[i][2], productInfo[i][3], productInfo[i][4]);

                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //Search and print product informations
        public void search(string path)
        {
            Console.Clear();
            ProductManagementOperations transfer = new ProductManagementOperations();
            Inventory check = new Inventory();

            Console.Write("Enter Product Code: ");
            string search = Console.ReadLine();

            bool found = check.checkInfo(path);
            bool searchtrue = false; 
            if (found == true)
            {
                string[][] productInfo = transfer.textArray(path);
                for (int i = 0; i < productInfo.Length; i++)
                {
                    if (productInfo[i][0] == search)
                    {
                        Console.Clear();
                        Console.WriteLine("Product No | Product Name | Price | Qty | Sold\n");
                        Console.Write("{0} - {1} - {2} - {3} - {4}\n", productInfo[i][0], productInfo[i][1], productInfo[i][2], productInfo[i][3], productInfo[i][4]);
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
        private string[][] textArray(string path)
        {
            Inventory check = new Inventory();
            string[][] productInfo = check.transfer(path);
            int counter = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                string[] info = line.Split('|');
                productInfo[counter] = new string[5] { info[0], info[1], info[2], info[3], info[4] };
                counter++;

            }
            return productInfo;
        }

        //Search and update product price
        public class PriceUpdate
        {

            //Search product
            public void update(string path)
            {
                Console.Clear();
                ProductManagementOperations transfer = new ProductManagementOperations();
                validation validate = new validation();
                Inventory check = new Inventory();

                Console.Write("Enter Product Code: ");
                string search = Console.ReadLine();

                bool found = check.checkInfo(path);
                bool searchtrue = false;
                if (found == true)
                {
                    string[][] productInfo = transfer.textArray(path);
                    for (int i = 0; i < productInfo.Length; i++)
                    {
                        if (productInfo[i][0] == search)
                        {
                            Console.Clear();
                            int newPrice = validate.numbersRequired("Enter product's new price: ");
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
            static void lineChanger(string newText, string fileName, int line_to_edit)
            {
                string[] arrLine = File.ReadAllLines(fileName);
                arrLine[line_to_edit] = newText;
                File.WriteAllLines(fileName, arrLine);
            }

        }
        class Data
        {
            public void add(string path,int code, string name, double price, int stock)
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
Console.Clear();
validation codeValidate = new validation();
int up = codeValidate.numberLengthRequired("Enter code to update Price:", 5);
string search = Convert.ToString(up);

FileStream paytonStm = new FileStream(path, FileMode.Open);
StreamReader paytonStmReader = new StreamReader(paytonStm);
bool found = false;
string paytonLine = paytonStmReader.ReadLine();
string[] lineContent = paytonLine.Split('|');

while (paytonLine != null)
{
    lineContent = paytonLine.Split('|');
    if (lineContent[0] == search)
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
    oldPrice = lineContent[2];
    PUpdate(path);
}
else
{
    Console.WriteLine("Product doesn't Exist!");
}
*/

/*
//Overwrite data
private void PUpdate(string path)
{
    Console.Clear();
    validation validate = new validation();
    Console.WriteLine();
    double price = validate.doubleInput("Enter Product Price: ");
    newPrice = Convert.ToString(price);

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
    StreamWriter paytonWriter = new StreamWriter(path);
    paytonWriter.Write(newContent);
    paytonWriter.Close();

}
    */