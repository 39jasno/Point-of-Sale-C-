using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Group11_Machine_Problem
{
    public class ProdManage
    {
        static void introduction()
        {
            Console.Write("Product Management\n" +
                "\n1 - Add new product"+
                "\n2 - Display Product Information"+
                "\n3 - Update Price"+
                "\n4 - Search for Product Information"+
                "\n5 - Exit"+
                "\n\nEnter your choice: ");
        }


        public void Main()
        {
            ProductManagementOperations product = new ProductManagementOperations();

            string menuChoice;
            do
            {
                Console.Clear();
                introduction();

                menuChoice = Console.ReadLine();

                if (menuChoice.Trim() == "1")
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("Add New Product\n"+
                            "\n1 - Keyboard" +
                            "\n2 - Mouse" +
                            "\n3 - Monitor" +
                            "\n4 - Speakers" +
                            "\n5 - Headphones" +
                            "\n6 - Return"+
                            "\n\nEnter your choice: ");

                        string AmenuChoice = Console.ReadLine();

                        if (AmenuChoice.Trim() == "1")
                        {
                            product.write("KeyboardData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "2")
                        {
                            product.write("MouseData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "3")
                        {
                            product.write("MonitorData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "4")
                        {
                            product.write("SpeakersData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "5")
                        {
                            product.write("HeadphonesData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "6")
                        {
                            Console.Clear();
                            break;

                        }

                        else
                        {
                            MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    } while (menuChoice!= "6");

                }

                else if (menuChoice.Trim() == "2")
                {
                    string BmenuChoice="";
                    do
                    {
                        
                        try
                        {
                            Console.Clear();
                            Console.Write("Display Product Information\n"+
                                "\n1 - Keyboard " +
                                "\n2 - Mouse " +
                                "\n3 - Monitor " +
                                "\n4 - Speakers " +
                                "\n5 - Headphones"+
                                "\n6 - Return"+
                                "\n\nInput choice: ");

                            BmenuChoice = Console.ReadLine();

                            if (BmenuChoice.Trim() == "1")
                            {
                                product.read("KeyboardData.txt");

                            }

                            else if (BmenuChoice.Trim() == "2")
                            {
                                product.read("MouseData.txt");

                            }

                            else if (BmenuChoice.Trim() == "3")
                            {
                                product.read("MonitorData.txt");

                            }

                            else if (BmenuChoice.Trim() == "4")
                            {
                                product.read("SpeakersData.txt");

                            }

                            else if (BmenuChoice.Trim() == "5")
                            {
                                product.read("HeadphonesData.txt");

                            }

                            else if (BmenuChoice.Trim() == "6")
                            {
                                Console.Clear();
                                break;

                            }

                            else
                            {
                                MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Input Data First!" +
                                "\n\nPress any key to continue...");
                            Console.ReadKey();
                        }

                    } while (BmenuChoice!="6");

                }

                else if (menuChoice.Trim() == "3")
                {
                    ProductManagementOperations.PriceUpdate update = new ProductManagementOperations.PriceUpdate();
                    do
                    {
                        try
                        {

                            Console.Write("Update Price\n" +
                                "\n1 - Keyboard " +
                                "\n2 - Mouse " +
                                "\n3 - Monitor " +
                                "\n4 - Speakers " +
                                "\n5 - Headphones" +
                                "\n6 - Return"+
                                "\n\nInput choice: ");

                            string CmenuChoice = Console.ReadLine();

                            if (CmenuChoice.Trim() == "1")
                            {
                                update.findUpdate("KeyboardData.txt");

                            }

                            else if (CmenuChoice.Trim() == "2")
                            {
                                update.findUpdate("MouseData.txt");

                            }

                            else if (CmenuChoice.Trim() == "3")
                            {
                                update.findUpdate("MonitorData.txt");

                            }

                            else if (CmenuChoice.Trim() == "4")
                            {
                                update.findUpdate("SpeakersData.txt");

                            }

                            else if (CmenuChoice.Trim() == "5")
                            {
                                update.findUpdate("HeadphonesData.txt");

                            }

                            else if (CmenuChoice.Trim() == "6")
                            {
                                Console.Clear();
                                break;
                            }

                            else
                            {
                                MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Input Data First!");
                        }


                    } while (true);

                }

                else if (menuChoice.Trim() == "4")
                {
                    string DmenuChoice = "";
                    do
                    {
                        try
                        {

                            Console.Write("Search For Product Information\n" +
                                "\n1 - Keyboard, " +
                                "\n2 - Mouse, " +
                                "\n3 - Monitor, " +
                                "\n4 - Speakers, " +
                                "\n5 - Headphones" +
                                "\n6 - Return" +
                                "\n\nInput choice: ");

                            DmenuChoice = Console.ReadLine();

                            if (DmenuChoice.Trim() == "1")
                            {
                                product.search("KeyboardData.txt");

                            }

                            else if (DmenuChoice.Trim() == "2")
                            {
                                product.search("MouseData.txt");

                            }

                            else if (DmenuChoice.Trim() == "3")
                            {
                                product.search("MonitorData.txt");

                            }

                            else if (DmenuChoice.Trim() == "4")
                            {
                                product.search("SpeakersData.txt");

                            }

                            else if (DmenuChoice.Trim() == "5")
                            {
                                product.search("HeadphonesData.txt");

                            }
                            else if (DmenuChoice.ToUpper() == "6")
                            {
                                Console.Clear();
                                break;

                            }

                            else
                            {
                                MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Input Data First!");
                        }

                    } while (DmenuChoice!="6");


                }
                else if (menuChoice.Trim() == "5")
                {
                    Console.Clear();
                    break;
                }

                else
                {
                    MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } while (menuChoice!= "5");
        }

    }

}
