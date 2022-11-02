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
            FileStream fileStream = File.OpenRead("KeyboardData.txt");
            Console.WriteLine(fileStream);

                string file = ("Sales.txt");
                var inputfile = "KeyboardData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
                Console.WriteLine("Enter product: ");
            string product = Console.ReadLine();
            Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Keyboard";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", price);
            Console.WriteLine("total quantity: {0:N2} ", qty);


        }
    }

    class Monitor
    {
        public Monitor()
        {
            FileStream fileStream = File.OpenRead("MonitorData.txt");
            Console.WriteLine(fileStream);
            int qty;
            double price;

                string file = ("Sales.txt");
                var inputfile = "MonitorData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
            Console.WriteLine("Enter product: ");
            string product = Console.ReadLine();
            Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Monitor";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
            Console.WriteLine("total price of chosen keyboard is: {0:N2} ", price);



        }
    }

    class Mouse
    {
        public Mouse()
        {
            FileStream fileStream = File.OpenRead("MouseData.txt");
            Console.WriteLine(fileStream);
            double price;
            int qty;
            
                string file = ("Sales.txt");
                var inputfile = "MouseData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
            Console.WriteLine("Enter product: ");
            string product = Console.ReadLine();
            Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Mouse";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
            Console.WriteLine("total price of chosen keyboard is: {0:N2} ", price);

            
        }
    }

    class Speaker
    {
        public Speaker()
        {
            FileStream fileStream = File.OpenRead("MouseData.txt");
            Console.WriteLine(fileStream);
            int qty;
            double price;
           
                string file = ("Sales.txt");
                var inputfile = "SpeakerData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
            Console.WriteLine("Enter product: ");
            string product = Console.ReadLine();
            Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Speaker";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
            Console.WriteLine("total price of chosen keyboard is: {0:N2} ", price);


        }
    }

    class Headphone
    {
        public Headphone()
        {
            FileStream fileStream = File.OpenRead("HeadphonesData.txt");
            Console.WriteLine(fileStream);
            int qty;
            double price;

                string file = ("Sales.txt");
                var inputfile = "HeadphonesData.txt";
                string[] output = File.ReadAllLines(inputfile, Encoding.UTF8);
                foreach (string op in output)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine();
            Console.WriteLine("Enter product: ");
            string product = Console.ReadLine();
            Console.WriteLine("Enter price: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                price *= qty;
                string categ = "Headphones";
                File.WriteAllText(file, categ);
                File.WriteAllText(file, Convert.ToString(qty));
                File.WriteAllText(file, Convert.ToString(price));
            Console.WriteLine("total price of chosen keyboard is: {0:N2} ", price);
            

        }
    }
}
