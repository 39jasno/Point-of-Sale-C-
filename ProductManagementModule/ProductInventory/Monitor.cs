using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;

namespace Group11_Machine_Problem
{
    class ProductMonitor
    {
        public void moniWrite()
        {
            validation moniValidate = new validation();
            int moniCode = moniValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string moniName = moniValidate.InputString("Enter Product Name: ");
            double moniPrice = moniValidate.doubleInput("Enter Product Price: ");
            int moniStock = moniValidate.numbersRequired("Enter Product Stock: ");
            int moniSold = moniValidate.numbersRequired("Enter Product Sold: ");


            moniData moniBase = new moniData();
            moniBase.addMoni(moniCode, moniName, moniPrice, moniStock, moniSold);


        }

        //Read and Print Product informations
        public void moniRead()
        {
            StreamReader paytonReader = new StreamReader("MonitorData.txt");
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
        public void moniSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchMoni = Console.ReadLine();

            FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] monitorLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                monitorLineContent = paytonLine.Split('|');
                if (monitorLineContent[0].Equals(searchMoni))
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
                Console.WriteLine(monitorLineContent[0] + "|" + monitorLineContent[1] + "|" + monitorLineContent[2] + "|" + monitorLineContent[3] + "|" + monitorLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class monitorPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void moniFindUpdate()
            {
                validation codeValidate = new validation();
                int moniUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchMoni = Convert.ToString(moniUp);

                FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] moniLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    moniLineContent = paytonLine.Split('|');
                    if (moniLineContent[0] == searchMoni)
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
                    oldPrice = moniLineContent[2];
                    moniPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void moniPUpdate()
            {

                validation moniValidate = new validation();
                Console.WriteLine();
                double newMoniPrice = moniValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newMoniPrice);

                FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
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
                StreamWriter paytonWriter = new StreamWriter("MonitorData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }



        class moniData
        {
            public void addMoni(int mmoniCode, string mmoniName, double mmoniPrice, int mmoniStock, int mmoniSold)
            {
                using (StreamWriter writer = new StreamWriter("MonitorData.txt", true))
                {
                    writer.WriteLine(mmoniCode + "|" + mmoniName + "|" + mmoniPrice + "|" + mmoniStock + "|" + mmoniSold);
                    writer.Close();
                }
            }
        }
    }
}
