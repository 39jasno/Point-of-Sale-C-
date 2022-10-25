using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;


namespace Group11_Machine_Problem
{
    class ProductKeyboard
    {
        //Add Product
        public void keybWrite()
        {
            validation keybValidate = new validation();
            int keybCode = keybValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string keybName = keybValidate.InputString("Enter Product Name: ");
            double keybPrice = keybValidate.doubleInput("Enter Product Price: ");
            int keybStock = keybValidate.numbersRequired("Enter Product Stock: ");
            int keybSold = keybValidate.numbersRequired("Enter Product Sold: ");


            keyboardData keyboardBase = new keyboardData();
            keyboardBase.addKeyb(keybCode, keybName, keybPrice, keybStock, keybSold);
        }


        //Read Product
        public void keybRead()
        {
            StreamReader paytonReader = new StreamReader("KeyboardData.txt");
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

        //Search Product and Print details
        public void keybSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchKeyb = Console.ReadLine();

            FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] keyboardLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                keyboardLineContent = paytonLine.Split('|');
                if (keyboardLineContent[0].Equals(searchKeyb))
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
                Console.WriteLine(keyboardLineContent[0] + "|" + keyboardLineContent[1] + "|" + keyboardLineContent[2] + "|" + keyboardLineContent[3] + "|" + keyboardLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Update Price
        public class keyboardPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;



            //Search for the ID to update
            public void keybFindUpdate()
            {
                validation codeValidate = new validation();
                int keybUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
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

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
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

        //Update Sold
        public class keyboardSold
        {
            private static string oldSold;
            private static string newSold;
            private static string oldStock;
            private static string newStock;


            //Search for the ID to update
            public void keybFindSoldUpdate()
            {
                validation codeValidate = new validation();
                int keybUp = codeValidate.numberLengthRequired("Enter code to update product sold:", 1, 10);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
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
                    oldSold = keyboardLineContent[4];
                    oldStock = keyboardLineContent[3];
                    keybSoldUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite Price data
            private void keybSoldUpdate()
            {

                validation keybValidate = new validation();
                Console.WriteLine();
                int newSold = keybValidate.numbersRequired("Enter how many units sold: ");
                int oldSold2 = Convert.ToInt32(oldSold);
                int oldStock2 = Convert.ToInt32(oldSold);
                int newKeybStock = oldStock2 - newSold;
                int newKeybSold = oldSold2 + newSold;
                string newKeybSold2 = Convert.ToString(newKeybSold);
                string newKeybStock2 = Convert.ToString(newKeybStock);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldStock, newKeybStock2);
                    paytonLine = paytonLine.Replace(oldSold, newKeybSold2);
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
    }
}

namespace Group11_Machine_Problem
{
    class keyboardData
    {
        public void addKeyb(int kkeybCode, string kkeybName, double kkeybPrice, int kkeybStock, int kkeybSold)
        {
            using (StreamWriter writer = new StreamWriter("KeyboardData.txt", true))
            {
                writer.WriteLine(kkeybCode + "|" + kkeybName + "|" + kkeybPrice + "|" + kkeybStock + "|" + kkeybSold);
                writer.Close();
            }
        }
    }

}
