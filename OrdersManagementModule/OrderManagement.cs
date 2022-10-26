using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Group11_Machine_Problem
{
    public class OrderManage
    {
        public void Main()
        {

  int menu;

            Console.WriteLine("----Main Menu----");
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. Return Order");
            menu = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (menu == 1)
            {
                Console.Write("Choose product of your choice" +
                    "\n1. Keyboard"+
                    "\n2. Monitor"+
                    "\n3. Mouse"+
                    "\n4. Speaker"+
                    "\n5. Headphones"+
                    "\n6. Exit"+
                    "\n\nInput coice: ");

                string choice = Console.ReadLine();


                if (choice == "1")
                {
                    Console.WriteLine();
                    Keyboard keyboard = new Keyboard();
                    StreamWriter writer = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else if (choice == "2")
                {
                    Console.WriteLine();
                    Monitor monitor = new Monitor();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);

                }

                else if (choice == "3")
                {
                    Console.WriteLine();
                    Mouse mouse = new Mouse();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else if (choice == "5")
                {
                    Console.WriteLine();
                    Speaker speaker = new Speaker();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else if (choice == "6")
                {
                    Console.WriteLine();
                    Headphone headphone = new Headphone();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    Console.WriteLine("Thank you for shopping");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else
                {
                    MessageBox.Show("Invalid");

                }

               
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("Products.txt"))
                {
                    writer.WriteLine(System.DateTime.Now.ToString());
                    writer.Close();
                }
                

            }
            Console.ReadKey();
                
        }
    }
}
