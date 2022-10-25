using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group11_Machine_Problem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose product of your choice");
            Console.WriteLine("1. Keyboard");
            Console.WriteLine("2. Monitor");
            Console.WriteLine("3. Mouse");
            Console.WriteLine("4. Speaker");
            Console.WriteLine("5. Headphones");
            Console.WriteLine("6. Continue shopping");
            int choice = Convert.ToInt32(Console.ReadLine());
            int paymentOption;



            if (choice == 1)
            {
                Keyboard keyboard = new Keyboard();
            }

            else if (choice == 2)
            {
                Monitor monitor = new Monitor();
            }

            else if (choice == 3)
            {
                Mouse mouse = new Mouse();
            }

            else if (choice == 4)
            {
                Speaker speaker = new Speaker();
            }

            else if (choice == 5)
            {
                Headphone headphone = new Headphone();
            }

            else
            {
                MessageBox.Show("Invalid");
            }

            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Cash on Delivery");
            Console.WriteLine("Enter your Payment option");
            paymentOption = Convert.ToInt32(Console.ReadLine());


            if (paymentOption == 1)
            {
                string num;
                Console.WriteLine("Enter your 4 digit number");
                num = Console.ReadLine();
                int length = num.Length;

                if (length == 4)
                {
                    Console.WriteLine("Thank you for shopping!");
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
            }


            else if (paymentOption == 2)
            {
                string name;
                string address;
                string contactNumber;
                Console.WriteLine("Enter your name");
                name = Console.ReadLine();
                Console.WriteLine("Enter your address");
                address = Console.ReadLine();
                Console.WriteLine("Enter your 11 digit Phone Number");
                contactNumber = Console.ReadLine();
                int length = contactNumber.Length;
                if (length == 11)
                {
                    Console.WriteLine("Thank you for shopping");
                }
                else
                {
                    MessageBox.Show("Invalid Number");
                }


            }



            Console.ReadKey();
        }
    }
}
