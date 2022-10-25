using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;

namespace Group11_Machine_Problem
{
    class ProductManagementOperations
    {
        public void write(string path)
        {
            validation validate = new validation();
            int code = validate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string name = validate.InputString("Enter Product Name: ");
            double price = validate.doubleInput("Enter Product Price: ");
            int stock = validate.numbersRequired("Enter Product Stock: ");
            int sold = validate.numbersRequired("Enter Product Sold: ");


            headpData speakBase = new headpData();
            speakBase.add(path, code, name, price, stock, sold);


        }

        //Read and Print Product informations
        public void read(string path)
        {
            StreamReader paytonReader = new StreamReader(path);
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search and print product informations
        public void search(string path)
        {
            Console.WriteLine("Enter Product Code:");
            string search = Console.ReadLine();

            FileStream paytonStm = new FileStream(path, FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] lineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                lineContent = paytonLine.Split('|');
                if (lineContent[0].Equals(search))
                {
                    found = true; break;
                }
                else
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if (found)
            {
                Console.WriteLine();
                Console.WriteLine(lineContent[0] + "|" + lineContent[1] + "|" + lineContent[2] + "|" + lineContent[3] + "|" + lineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class PriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void findUpdate(string path)
            {
                validation codeValidate = new validation();
                int up = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
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

            }

            //Overwrite data
            private void PUpdate(string path)
            {

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
        }



        class headpData
        {
            public void add(string path,int code, string name, double price, int stock, int sold)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(code + "|" + name + "|" + price + "|" + stock + "|" + sold);
                    writer.Close();
                }
            }
        }
    }
}
