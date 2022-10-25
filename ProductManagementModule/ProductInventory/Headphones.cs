using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group11_Machine_Problem
{
    class ProductHeadphones
    {
        public void headpWrite()
        {
            validation headpValidate = new validation();
            int headpCode = headpValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string headpName = headpValidate.InputString("Enter Product Name: ");
            double headPrice = headpValidate.doubleInput("Enter Product Price: ");
            int headpStock = headpValidate.numbersRequired("Enter Product Stock: ");
            int headpSold = headpValidate.numbersRequired("Enter Product Sold: ");


            headpData speakBase = new headpData();
            speakBase.addHeadphones(headpCode, headpName, headPrice, headpStock, headpSold);


        }

        //Read and Print Product informations
        public void headpRead()
        {
            StreamReader paytonReader = new StreamReader("HeadphonesData.txt");
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
        public void headpSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchHeadp = Console.ReadLine();

            FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] headphonesLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                headphonesLineContent = paytonLine.Split('|');
                if (headphonesLineContent[0].Equals(searchHeadp))
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
                Console.WriteLine(headphonesLineContent[0] + "|" + headphonesLineContent[1] + "|" + headphonesLineContent[2] + "|" + headphonesLineContent[3] + "|" + headphonesLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class headphonesPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void headpFindUpdate()
            {
                validation codeValidate = new validation();
                int headpUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchHeadp = Convert.ToString(headpUp);

                FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] headpLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    headpLineContent = paytonLine.Split('|');
                    if (headpLineContent[0] == searchHeadp)
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
                    oldPrice = headpLineContent[2];
                    headpPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void headpPUpdate()
            {

                validation headpValidate = new validation();
                Console.WriteLine();
                double newHeadpPrice = headpValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newHeadpPrice);

                FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
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
                StreamWriter paytonWriter = new StreamWriter("HeadphonesData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }



        class headpData
        {
            public void addHeadphones(int hheadpCode, string hheadpName, double hheadPrice, int hheadpStock, int hheadpSold)
            {
                using (StreamWriter writer = new StreamWriter("HeadphonesData.txt", true))
                {
                    writer.WriteLine(hheadpCode + "|" + hheadpName + "|" + hheadPrice + "|" + hheadpStock + "|" + hheadpSold);
                    writer.Close();
                }
            }
        }
    }
}
