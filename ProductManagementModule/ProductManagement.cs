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
            ProductKeyboard keyboard = new ProductKeyboard();
            ProductMouse mouse = new ProductMouse();
            ProductMonitor monitor = new ProductMonitor();
            ProductSpeaker speaker = new ProductSpeaker();
            ProductHeadphones headphones = new ProductHeadphones();
            ProductManagementOperations product = new ProductManagementOperations();

            DialogResult dialogtryagain;
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
                        Console.Write("\nAdd New Product"+
                            "\n[1] Keyboard" +
                            "\n[2] Mouse" +
                            "\n[3] Monitor" +
                            "\n[4] Speakers" +
                            "\n[5] Headphones" +
                            "\n[6] Return"+
                            "\n\nEnter your choice: ");

                        string AmenuChoice = Console.ReadLine();

                        if (AmenuChoice.Trim() == "1")
                        {
                            product.write(@".\\ProductInventory\\KeyboardData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "2")
                        {
                            product.write("MouseData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "3")
                        {
                            product.write("Keyboard.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "4")
                        {
                            product.write("MonitorData.txt");
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


                    } while (true);

                }

                else if (menuChoice.Trim() == "2")
                {
                    do
                    {
                        try
                        {

                            Console.WriteLine("");
                            Console.WriteLine("What product type are you going to display?");
                            Console.WriteLine("[A] Keyboard, [B] Mouse, [C] Monitor, [D] Speakers, [E] Headphones");
                            Console.WriteLine("[F] Return");
                            Console.WriteLine("Input choice: ");
                            string BmenuChoice = Console.ReadLine();

                            if (BmenuChoice.ToUpper() == "A")
                            {

                                keyboard.keybRead();

                            }

                            else if (BmenuChoice.ToUpper() == "B")
                            {


                                mouse.mouseRead();

                            }

                            else if (BmenuChoice.ToUpper() == "C")
                            {


                                monitor.moniRead();

                            }

                            else if (BmenuChoice.ToUpper() == "D")
                            {


                                speaker.speakRead();

                            }

                            else if (BmenuChoice.ToUpper() == "E")
                            {


                                headphones.headpRead();

                            }

                            else if (BmenuChoice.ToUpper() == "F")
                            {
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

                else if (menuChoice.Trim() == "3")
                {
                    do
                    {
                        try
                        {

                            Console.WriteLine("");
                            Console.WriteLine("What product type are you going to update the price of?:");
                            Console.WriteLine("[A] Keyboard, [B] Mouse, [C] Monitor, [D] Speakers, [E] Headphones");
                            Console.WriteLine("[F] Return");
                            Console.WriteLine("Input choice: ");
                            string CmenuChoice = Console.ReadLine();

                            if (CmenuChoice.ToUpper() == "A")
                            {

                                ProductKeyboard.keyboardPriceUpdate updateKeyboard = new ProductKeyboard.keyboardPriceUpdate();

                                updateKeyboard.keybFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "B")
                            {

                                ProductMouse.mousePriceUpdate updateMouse = new ProductMouse.mousePriceUpdate();

                                updateMouse.mouseFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "C")
                            {

                                ProductMonitor.monitorPriceUpdate updateMonitor = new ProductMonitor.monitorPriceUpdate();

                                updateMonitor.moniFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "D")
                            {

                                ProductSpeaker.speakerPriceUpdate updateSpeaker = new ProductSpeaker.speakerPriceUpdate();

                                updateSpeaker.speakFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "E")
                            {

                                ProductHeadphones.headphonesPriceUpdate updateHeadphones = new ProductHeadphones.headphonesPriceUpdate();

                                updateHeadphones.headpFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "F")
                            {
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
                    do
                    {
                        try
                        {

                            Console.WriteLine("");
                            Console.WriteLine("What product type are you going to search for?");
                            Console.WriteLine("[A] Keyboard, [B] Mouse, [C] Monitor, [D] Speakers, [E] Headphones");
                            Console.WriteLine("[F] Return");
                            Console.WriteLine("Input choice: ");
                            string DmenuChoice = Console.ReadLine();

                            if (DmenuChoice.ToUpper() == "A")
                            {

                                keyboard.keybSearch();
                            }


                            else if (DmenuChoice.ToUpper() == "B")
                            {


                                mouse.mouseSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "C")
                            {

                                monitor.moniSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "D")
                            {

                                speaker.speakSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "E")
                            {

                                headphones.headpSearch();

                            }
                            else if (DmenuChoice.ToUpper() == "F")
                            {
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
                else if (menuChoice.Trim() == "5")
                {
                    Console.Clear();
                    break;
                }

                else
                {
                    MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                dialogtryagain = MessageBox.Show("Would you like to close the program?", "Inquiry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            } while (menuChoice!= "5");
        }

    }

}
