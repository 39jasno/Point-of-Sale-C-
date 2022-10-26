using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Group11_Machine_Problem
{
     class Keyboard
    {
        public Keyboard()
        {
            int qty;
            double price;
            FileStream fileStream = File.OpenRead(@".\Inventory\KeyboardData.txt");

            string keychoice = Console.ReadLine();
            if (keychoice == "1")
            {

                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine(); 
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
               
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", productname);
            }

            else if (keychoice == "2")
            {
                
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", productname);
            }

            else if (keychoice == "3")
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", productname);
            }

            else
            {
                MessageBox.Show("Invalid");
            }

        }
    }

    class Monitor
    {
        public Monitor()
        {
            FileStream fileStream = File.OpenRead(@".\Inventory\MonitorData.txt");
            int qty;
            double price;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen  is: {0:N2} ", productname);
                
            }

            else if (keychoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Monitor is: {0:N2} ", productname);
            }

            else
            {
                MessageBox.Show("Invalid");
            }

        }
    }

    class Mouse
    {
        public Mouse()
        {
            FileStream fileStream = File.OpenRead(@".\Inventory\MouseData.txt");
            double price;
            int qty;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Mouse is: {0:N2} ", productname);

                int cont = Convert.ToInt32(Console.ReadLine());
            }

            else if (keychoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Mouse is: {0:N2} ", productname);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }

    class Speaker
    {
        public Speaker()
        {
            FileStream fileStream = File.OpenRead(@".\Inventory\MouseData.txt");
            int qty;
            double price;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Speaker is: {0:N2} ", productname);
            }

            else if (keychoice == 2)
            {

                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Speaker is: {0:N2} ", productname);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }

    class Headphone
    {
        public Headphone()
        {
            FileStream fileStream = File.OpenRead(@".\Inventory\HeadphonesData.txt");
            int qty;
            double price;
            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Headphone is: {0:N2} ", productname);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Enter product Name: ");
                string productname = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                Console.WriteLine("total price of chosen Headphone is: {0:N2} ", productname);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
