using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group11_Machine_Problem.FileCheck;
using System.IO;

namespace Group11_Machine_Problem
{
    class OMM
    {
        public void order()
        {
            OMM menu = new OMM();
            string choice;
            do
            {
                menu.ommMenu();
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    ommcreate();
                }
            } while (choice != "3");
            

        }

        public void ommcreate()
        {
            Console.Clear();
            Console.WriteLine("Create an order\n");

            OMM menu = new OMM();
            Inventory check = new Inventory();

            string category;
            do
            {
                menu.category();
                category = Console.ReadLine();
                int counter = 0;
                string[][] finalCart;
                if (category == "1")
                {
                    string path = "KeyboardData.txt";
                    displayProduct(path, counter);

                    //finalCart = cart(finalCart, counter);
                }
                else
                {
                    counter++;
                }
                for (int i = 0; i < finalCart.Length; i++)
                {
                    string format = String.Format("{0,-10}{1,-10}", finalCart[i][0], finalCart[i][1]);
                    Console.WriteLine(format);
                }

            } while (category!= "6") ;



        }
        public void ommreturn()
        {
            Console.WriteLine("Return an item");

        }

        private void ommMenu()
        {
            Console.Write("Order Management\n" +
                "\n1 - Create an order" +
                "\n2 - Return an item" +
                "\n3 - Exit"+
                "\n\nInput choice: ");
        }
        private string[][] displayProduct(string path, int cartCounter)
        {
            Console.Clear();
            Inventory check = new Inventory();

            bool found = check.CheckInfo(path);
            string[][] array = check.Transfer(path);

            if (found == true)
            {
                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');
                    array[counter] = new string[3] { info[0], info[1], info[2] };

                    counter++;
                }

                string title = String.Format("{0,-10}{1,-10}{2,-10}\n", "Code No.", "Product", "Price");
                Console.WriteLine(title);

                for (int i = 0; i < array.Length; i++)
                {
                    string format = String.Format("{0,-10}{1,-10}{2,-10}", array[i][0], array[i][1], array[i][2]);
                    Console.WriteLine(format);

                }
                return array;
            }
            else
            {
                return array;
            }

        }
        private string[][] cart(string[][] finalCart, int cartCtr)
        {
            Console.Write("\nEnter product code: ");
            string prodcode = Console.ReadLine();
            Console.Write("Enter quantity: ");
            string qty = Console.ReadLine();
            finalCart[cartCtr] = new string[2] { prodcode, qty };

            return finalCart;
        }
        private void category()
        {
            Console.Write("Choose a product category\n" +
                "\n1 - Keyboard" +
                "\n2 - Monitor" +
                "\n3 - Mouse" +
                "\n4 - Speakers" +
                "\n5 - Headphones"+
                "\n6 - Checkout"+
                "\n\nInput choice: ");
        }
    }
}
