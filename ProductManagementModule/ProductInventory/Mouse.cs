using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;

namespace Group11_Machine_Problem
{
    class ProductMouse
    {
        public void mouseWrite()
        {
            validation mouseValidate = new validation();
            int mouseCode = mouseValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string mouseName = mouseValidate.InputString("Enter Product Name: ");
            double mousePrice = mouseValidate.doubleInput("Enter Product Price: ");
            int mouseStock = mouseValidate.numbersRequired("Enter Product Stock: ");
            int mouseSold = mouseValidate.numbersRequired("Enter Product Sold: ");


            mouseData mouseBase = new mouseData();
            mouseBase.addMouse(mouseCode, mouseName, mousePrice, mouseStock, mouseSold);


        }

        //Read and Print Product informations
        public void mouseRead()
        {
            StreamReader paytonReader = new StreamReader("MouseData.txt");
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
        public void mouseSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchMouse = Console.ReadLine();

            FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] mouseLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                mouseLineContent = paytonLine.Split('|');
                if (mouseLineContent[0].Equals(searchMouse))
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
                Console.WriteLine(mouseLineContent[0] + "|" + mouseLineContent[1] + "|" + mouseLineContent[2] + "|" + mouseLineContent[3] + "|" + mouseLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class mousePriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void mouseFindUpdate()
            {
                validation codeValidate = new validation();
                int mouseUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchMouse = Convert.ToString(mouseUp);

                FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] mouseLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    mouseLineContent = paytonLine.Split('|');
                    if (mouseLineContent[0] == searchMouse)
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
                    oldPrice = mouseLineContent[2];
                    mousePUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void mousePUpdate()
            {

                validation mouseValidate = new validation();
                Console.WriteLine();
                double newMousePrice = mouseValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newMousePrice);

                FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
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
                StreamWriter paytonWriter = new StreamWriter("MouseData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }


        class mouseData
        {
            public void addMouse(int mmouseCode, string mmouseName, double mmousePrice, int mmouseStock, int mmouseSold)
            {
                using (StreamWriter writer = new StreamWriter("MouseData.txt", true))
                {
                    writer.WriteLine(mmouseCode + "|" + mmouseName + "|" + mmousePrice + "|" + mmouseStock + "|" + mmouseSold);
                    writer.Close();
                }
            }
        }
    }
}
