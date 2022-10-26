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
            Console.Write("Order management\n"+
            "\n1 - Create Order"+
            "\n2 - Return Order"+
            "\n\nInput choice: ");

            string menu = Console.ReadLine();
            Console.Clear();

            if (menu == "1")
            {
               
                OrderManage mainmenu = new OrderManage();
                mainmenu.showMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine();
                    Keyboard keyboard = new Keyboard();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }



                else if (choice == 2)
                {
                    Console.WriteLine();
                    Monitor monitor = new Monitor();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);

                }

                else if (choice == 3)
                {
                    Console.WriteLine();
                    Mouse mouse = new Mouse();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else if (choice == 4)
                {
                    Console.WriteLine();
                    Speaker speaker = new Speaker();
                    StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                    DateTime dt = new DateTime();
                    Console.WriteLine(dt);
                }

                else if (choice == 5)
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
                StreamWriter moscosoWriter = new StreamWriter("Products.txt");
                moscosoWriter.WriteLine(System.DateTime.Now.ToString());
                moscosoWriter.Close();

            }
             Console.ReadKey();

        }
        private void showMenu()
        {
            Console.Write("Choose product of your choice\n"+
            "\n1. Keyboard"+
            "\n2. Monitor"+
            "\n3. Mouse"+
            "\n4. Speaker"+
            "\n5. Headphones"+
            "\n6. Exit"+
            "\n\nInput choice: ");
        }
                
        }
    }

