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
            Console.WriteLine("Product Management");
            Console.WriteLine("===========================");
            Console.WriteLine("");

            Console.WriteLine("[A] Add new product");
            Console.WriteLine("[B] Display Product Information");
            Console.WriteLine("[C] Update Price");
            Console.WriteLine("[D] Search for Product Information");
        }


        public void Main()
        {
            
            DialogResult dialogtryagain;
            do
            {
                ProductKeyboard keyboard = new ProductKeyboard();
                ProductMouse mouse = new ProductMouse();
                ProductMonitor monitor = new ProductMonitor();
                ProductSpeaker speaker = new ProductSpeaker();
                ProductHeadphones headphones = new ProductHeadphones();

                Console.Clear();
                introduction();
                Console.WriteLine("Input choice: ");
                string menuChoice = Console.ReadLine();


                if (menuChoice.ToUpper() == "A")
                {
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("What product type are you going to insert?");
                        Console.WriteLine("[A] Keyboard, [B] Mouse, [C] Monitor, [D] Speakers, [E] Headphones");
                        Console.WriteLine("[F] Return");
                        Console.WriteLine("Input choice: ");
                        string AmenuChoice = Console.ReadLine();

                        if (AmenuChoice.ToUpper() == "A")
                        {
                            keyboard.keybWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "B")
                        {
                            mouse.mouseWrite();
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.ToUpper() == "C")
                        {
                            monitor.moniWrite();
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.ToUpper() == "D")
                        {

                            speaker.speakWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "E")
                        {

                            headphones.headpWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "F")
                        {
                            break;
                        }

                        else
                        {
                            MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    

                    } while (true);

                }

                else if (menuChoice.ToUpper() == "B")
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

                else if (menuChoice.ToUpper() == "C")
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

                else if (menuChoice.ToUpper() == "D")
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


                else
                {
                    MessageBox.Show("Invalid Input! Please try again", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                }

                dialogtryagain = MessageBox.Show("Would you like to close the program?", "Inquiry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            } while (dialogtryagain == DialogResult.No);
        }

    }


    class validation
    {
        public string InputString(string message)
        {
            string svalue;
            do
            {
                Console.WriteLine(message);
                svalue = Console.ReadLine().ToUpper().Trim();
            } while (svalue == String.Empty);
            return svalue;
        }


        public int numberLengthRequired(String strmessage, int minimum1, int maximum1)
        {
            int number; bool lnumber; string numlen;
            do
            {
                Console.WriteLine(strmessage);

                lnumber = int.TryParse(Console.ReadLine(), out number);
                numlen = number.ToString();

                if (!lnumber || numlen.Length < minimum1 || numlen.Length > maximum1)
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!lnumber || numlen.Length < minimum1 || numlen.Length > maximum1);
            return number;

        }

        public int numbersRequired(String strmessage)
        {
            int score; bool lscore;
            do
            {
                Console.WriteLine(strmessage);
                lscore = int.TryParse(Console.ReadLine(), out score);
                if (!lscore)
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!lscore);
            return score;
        }


        

        public double doubleInput(String strmessage)
        {
            double inputDouble; bool boolDouble;

            do
            {
                Console.WriteLine(strmessage);
                boolDouble = double.TryParse(Console.ReadLine(), out inputDouble);

                if (!boolDouble)
                    MessageBox.Show("Invalid Input", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (!boolDouble);
            return inputDouble;
        }
    }

}
