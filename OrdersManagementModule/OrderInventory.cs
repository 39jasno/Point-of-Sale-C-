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

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\KeyboardData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Keyboard product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Keyboard";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", file);
            }

            else if (keychoice == 2)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\KeyboardData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Keyboard product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Keyboard";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", file);
            }

            else if (keychoice == 3)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\KeyboardData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Keyboard product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Keyboard";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", file);
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
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\MonitorData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Monitor product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Monitor";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen  is: {0:N2} ", file);
                
            }

            else if (keychoice == 2)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\MonitorData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Monitor product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Monitor";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Monitor is: {0:N2} ", file);
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
            System.IO.File.ReadAllLines(@".\Inventory\KeyboardData.txt");
            FileStream fileStream = File.OpenRead(@".\Inventory\MouseData.txt");
            double price;
            int qty;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\MouseData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Mouse product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Mouse";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Mouse is: {0:N2} ", file);

                int cont = Convert.ToInt32(Console.ReadLine());
            }

            else if (keychoice == 2)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\MouseData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Mouse product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Mouse";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Mouse is: {0:N2} ", file);
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
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\SpeakerData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Speaker product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Speaker";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Speaker is: {0:N2} ", file);
            }

            else if (keychoice == 2)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\SpeakerData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Speaker product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter product Name: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Speaker";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Speaker is: {0:N2} ", file);
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
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\HeadphonesData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Headphone product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Headphones";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Headphone is: {0:N2} ", file); ;
            }

            else if (keychoice == 2)
            {
                string file = (@".\Inventory\Sales.txt");
                var inputfile = @".\Inventory\HeadphonesData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach(string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter Headphone product:");
                string product = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Headphones";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, product);
                File.WriteAllText(file, Convert.ToString(qty)); 
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen Headphone is: {0:N2} ", file);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
