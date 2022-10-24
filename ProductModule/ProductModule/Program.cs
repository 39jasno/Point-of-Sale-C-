using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductModule
{
    internal class Program
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


        static void Main(string[] args)
        {
            DialogResult dialogtryagain;
            do
            {
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

                            addKeyboard addKeyboard = new addKeyboard();

                            addKeyboard.keybWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "B")
                        {

                            addMouse addMouse = new addMouse();

                            addMouse.mouseWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "C")
                        {

                            addMonitor addMonitor = new addMonitor();

                            addMonitor.moniWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "D")
                        {

                            addSpeaker addSpeaker = new addSpeaker();

                            addSpeaker.speakWrite();
                            Console.WriteLine("Data successfully inputted");
                        }

                        else if (AmenuChoice.ToUpper() == "E")
                        {

                            addHeadphones addHeadphones = new addHeadphones();

                            addHeadphones.headpWrite();
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

                                addKeyboard dispKeyboard = new addKeyboard();

                                dispKeyboard.keybRead();

                            }

                            else if (BmenuChoice.ToUpper() == "B")
                            {

                                addMouse dispMouse = new addMouse();

                                dispMouse.mouseRead();

                            }

                            else if (BmenuChoice.ToUpper() == "C")
                            {

                                addMonitor dispMonitor = new addMonitor();

                                dispMonitor.moniRead();

                            }

                            else if (BmenuChoice.ToUpper() == "D")
                            {

                                addSpeaker dispSpeaker = new addSpeaker();

                                dispSpeaker.speakRead();

                            }

                            else if (BmenuChoice.ToUpper() == "E")
                            {

                                addHeadphones dispHeadphones = new addHeadphones();

                                dispHeadphones.headpRead();

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

                                addKeyboard.keyboardPriceUpdate updateKeyboard = new addKeyboard.keyboardPriceUpdate();

                                updateKeyboard.keybFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "B")
                            {

                                addMouse.mousePriceUpdate updateMouse = new addMouse.mousePriceUpdate();

                                updateMouse.mouseFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "C")
                            {

                                addMonitor.monitorPriceUpdate updateMonitor = new addMonitor.monitorPriceUpdate();

                                updateMonitor.moniFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "D")
                            {

                                addSpeaker.speakerPriceUpdate updateSpeaker = new addSpeaker.speakerPriceUpdate();

                                updateSpeaker.speakFindUpdate();

                            }

                            else if (CmenuChoice.ToUpper() == "E")
                            {

                                addHeadphones.headphonesPriceUpdate updateHeadphones = new addHeadphones.headphonesPriceUpdate();

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
                                addKeyboard searchKeyboard = new addKeyboard();

                                searchKeyboard.keybSearch();
                            }


                            else if (DmenuChoice.ToUpper() == "B")
                            {

                                addMouse searchMouse = new addMouse();

                                searchMouse.mouseSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "C")
                            {

                                addMonitor searchMonitor = new addMonitor();

                                searchMonitor.moniSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "D")
                            {

                                addSpeaker searchSpeaker = new addSpeaker();

                                searchSpeaker.speakSearch();

                            }

                            else if (DmenuChoice.ToUpper() == "E")
                            {

                                addHeadphones searchHeadphones = new addHeadphones();

                                searchHeadphones.headpSearch();

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
    // Validation


    //Keyboard Class
    class addKeyboard
    {
        //Add Product
        public void keybWrite()
        {
            validation keybValidate = new validation();
            int keybCode = keybValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string keybName = keybValidate.InputString("Enter Product Name: ");
            double keybPrice = keybValidate.doubleInput("Enter Product Price: ");
            int keybStock = keybValidate.numbersRequired("Enter Product Stock: ");
            int keybSold = keybValidate.numbersRequired("Enter Product Sold: ");


            keyboardData keyboardBase = new keyboardData();
            keyboardBase.addKeyb(keybCode, keybName, keybPrice, keybStock, keybSold);


        }


        //Read Product
        public void keybRead()
        {
            StreamReader paytonReader = new StreamReader("KeyboardData.txt");
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search Product and Print details
        public void keybSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchKeyb = Console.ReadLine();

            FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] keyboardLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                keyboardLineContent = paytonLine.Split('|');
                if (keyboardLineContent[0].Equals(searchKeyb))
                {
                    found = true; break;
                }
                else 
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if(found)
            {
                Console.WriteLine();
                Console.WriteLine(keyboardLineContent[0] + "|" + keyboardLineContent[1] + "|" + keyboardLineContent[2] + "|" + keyboardLineContent[3] + "|" + keyboardLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Update Price
        public class keyboardPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;
            


            //Search for the ID to update
            public void keybFindUpdate()
            {
                validation codeValidate = new validation();
                int keybUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] keyboardLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    keyboardLineContent = paytonLine.Split('|');
                    if (keyboardLineContent[0] == searchKeyb)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = keyboardLineContent[2];
                    keybPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite Price data
            private void keybPUpdate()
            {

                validation keybValidate = new validation();
                Console.WriteLine();
                double newKeybPrice = keybValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newKeybPrice);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("KeyboardData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }

        //Update Sold
        public class keyboardSold
        {
            private static string oldSold;
            private static string newSold;
            private static string oldStock;
            private static string newStock;


            //Search for the ID to update
            public void keybFindSoldUpdate()
            {
                validation codeValidate = new validation();
                int keybUp = codeValidate.numberLengthRequired("Enter code to update product sold:", 1, 10);
                string searchKeyb = Convert.ToString(keybUp);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] keyboardLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    keyboardLineContent = paytonLine.Split('|');
                    if (keyboardLineContent[0] == searchKeyb)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldSold = keyboardLineContent[4];
                    oldStock = keyboardLineContent[3];                   
                    keybSoldUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite Price data
            private void keybSoldUpdate()
            {

                validation keybValidate = new validation();
                Console.WriteLine();
                int newSold = keybValidate.numbersRequired("Enter how many units sold: ");
                int oldSold2 = Convert.ToInt32(oldSold);
                int oldStock2 = Convert.ToInt32(oldSold);
                int newKeybStock = oldStock2 - newSold;
                int newKeybSold = oldSold2 + newSold;
                string newKeybSold2 = Convert.ToString(newKeybSold);
                string newKeybStock2 = Convert.ToString(newKeybStock);

                FileStream paytonStm = new FileStream("KeyboardData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldStock, newKeybStock2);
                    paytonLine = paytonLine.Replace(oldSold, newKeybSold2);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("KeyboardData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }
    }
        

        class keyboardData
        {
            public void addKeyb(int kkeybCode, string kkeybName, double kkeybPrice, int kkeybStock, int kkeybSold)
            {
                using (StreamWriter writer = new StreamWriter("KeyboardData.txt", true))
                {
                    writer.WriteLine(kkeybCode + "|" + kkeybName + "|" + kkeybPrice + "|" + kkeybStock + "|" + kkeybSold);
                    writer.Close();
                }
            }
        }

    

    //Mouse Class
    class addMouse
    {
        //Add product
        public void mouseWrite()
        {
            validation mouseValidate = new validation();
            int mouseCode = mouseValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string mouseName = mouseValidate.InputString("Enter Product Name: ");
            double mousePrice = mouseValidate.doubleInput("Enter Product Price: ");
            int mouseStock = mouseValidate.numbersRequired("Enter Product Stock: ");
            int mouseSold = mouseValidate.numbersRequired("Enter Product Sold: ");


            mouseData mouseBase = new mouseData();
            mouseBase.addMouse(mouseCode, mouseName, mousePrice, mouseStock, mouseSold);


        }

        //Read and Print Product informations
        public void mouseRead()
        {
            StreamReader paytonReader = new StreamReader("MouseData.txt");
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search and print product informations
        public void mouseSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchMouse = Console.ReadLine();

            FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] mouseLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                mouseLineContent = paytonLine.Split('|');
                if (mouseLineContent[0].Equals(searchMouse))
                {
                    found = true; break;
                }
                else
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if (found)
            {
                Console.WriteLine();
                Console.WriteLine(mouseLineContent[0] + "|" + mouseLineContent[1] + "|" + mouseLineContent[2] + "|" + mouseLineContent[3] + "|" + mouseLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class mousePriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void mouseFindUpdate()
            {
                validation codeValidate = new validation();
                int mouseUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchMouse = Convert.ToString(mouseUp);

                FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] mouseLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    mouseLineContent = paytonLine.Split('|');
                    if (mouseLineContent[0] == searchMouse)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = mouseLineContent[2];
                    mousePUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void mousePUpdate()
            {

                validation mouseValidate = new validation();
                Console.WriteLine();
                double newMousePrice = mouseValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newMousePrice);

                FileStream paytonStm = new FileStream("MouseData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("MouseData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }


        class mouseData
        {
            public void addMouse(int mmouseCode, string mmouseName, double mmousePrice, int mmouseStock, int mmouseSold)
            {
                using (StreamWriter writer = new StreamWriter("MouseData.txt", true))
                {
                    writer.WriteLine(mmouseCode + "|" + mmouseName + "|" + mmousePrice + "|" + mmouseStock + "|" + mmouseSold);
                    writer.Close();
                }
            }
        }

    }

    //Monitor Class
    class addMonitor
    {
        //Add product
        public void moniWrite()
        {
            validation moniValidate = new validation();
            int moniCode = moniValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string moniName = moniValidate.InputString("Enter Product Name: ");
            double moniPrice = moniValidate.doubleInput("Enter Product Price: ");
            int moniStock = moniValidate.numbersRequired("Enter Product Stock: ");
            int moniSold = moniValidate.numbersRequired("Enter Product Sold: ");


            moniData moniBase = new moniData();
            moniBase.addMoni(moniCode, moniName, moniPrice, moniStock, moniSold);


        }

        //Read and Print Product informations
        public void moniRead()
        {
            StreamReader paytonReader = new StreamReader("MonitorData.txt");
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search and print product informations
        public void moniSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchMoni = Console.ReadLine();

            FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] monitorLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                monitorLineContent = paytonLine.Split('|');
                if (monitorLineContent[0].Equals(searchMoni))
                {
                    found = true; break;
                }
                else
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if (found)
            {
                Console.WriteLine();
                Console.WriteLine(monitorLineContent[0] + "|" + monitorLineContent[1] + "|" + monitorLineContent[2] + "|" + monitorLineContent[3] + "|" + monitorLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class monitorPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void moniFindUpdate()
            {
                validation codeValidate = new validation();
                int moniUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchMoni = Convert.ToString(moniUp);

                FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] moniLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    moniLineContent = paytonLine.Split('|');
                    if (moniLineContent[0] == searchMoni)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = moniLineContent[2];
                    moniPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void moniPUpdate()
            {

                validation moniValidate = new validation();
                Console.WriteLine();
                double newMoniPrice = moniValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newMoniPrice);

                FileStream paytonStm = new FileStream("MonitorData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("MonitorData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }



        class moniData
        {
            public void addMoni(int mmoniCode, string mmoniName, double mmoniPrice, int mmoniStock, int mmoniSold)
            {
                using (StreamWriter writer = new StreamWriter("MonitorData.txt", true))
                {
                    writer.WriteLine(mmoniCode + "|" + mmoniName + "|" + mmoniPrice + "|" + mmoniStock + "|" + mmoniSold);
                    writer.Close();
                }
            }
        }

    }

    //Speaker Class
    class addSpeaker
    {
        //Add product
        public void speakWrite()
        {
            validation speakValidate = new validation();
            int speakCode = speakValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string speakName = speakValidate.InputString("Enter Product Name: ");
            double speakPrice = speakValidate.doubleInput("Enter Product Price: ");
            int speakStock = speakValidate.numbersRequired("Enter Product Stock: ");
            int speakSold = speakValidate.numbersRequired("Enter Product Sold: ");


            speakData speakBase = new speakData();
            speakBase.addSpeak(speakCode, speakName, speakPrice, speakStock, speakSold);

        }

        //Read and Print Product informations
        public void speakRead()
        {
            StreamReader paytonReader = new StreamReader("SpeakerData.txt");
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search and print product informations
        public void speakSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchSpeak = Console.ReadLine();

            FileStream paytonStm = new FileStream("SpeakerData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] speakerLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                speakerLineContent = paytonLine.Split('|');
                if (speakerLineContent[0].Equals(searchSpeak))
                {
                    found = true; break;
                }
                else
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if (found)
            {
                Console.WriteLine();
                Console.WriteLine(speakerLineContent[0] + "|" + speakerLineContent[1] + "|" + speakerLineContent[2] + "|" + speakerLineContent[3] + "|" + speakerLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class speakerPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void speakFindUpdate()
            {
                validation codeValidate = new validation();
                int speakUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchSpeak = Convert.ToString(speakUp);

                FileStream paytonStm = new FileStream("SpeakerData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] speakLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    speakLineContent = paytonLine.Split('|');
                    if (speakLineContent[0] == searchSpeak)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = speakLineContent[2];
                    speakPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void speakPUpdate()
            {

                validation speakValidate = new validation();
                Console.WriteLine();
                double newSpeakPrice = speakValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newSpeakPrice);

                FileStream paytonStm = new FileStream("SpeakerData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("SpeakerData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }

        class speakData
        {
            public void addSpeak(int sspeakCode, string sspeakName, double sspeakPrice, int sspeakStock, int sspeakSold)
            {
                using (StreamWriter writer = new StreamWriter("SpeakerData.txt", true))
                {
                    writer.WriteLine(sspeakCode + "|" + sspeakName + "|" + sspeakPrice + "|" + sspeakStock + "|" + sspeakSold);
                    writer.Close();
                }
            }
        }

    }

    //Headphones Class
    class addHeadphones
    {
        //Add product
        public void headpWrite()
        {
            validation headpValidate = new validation();
            int headpCode = headpValidate.numberLengthRequired("Enter Product ID: ", 1, 10);
            string headpName = headpValidate.InputString("Enter Product Name: ");
            double headPrice = headpValidate.doubleInput("Enter Product Price: ");
            int headpStock = headpValidate.numbersRequired("Enter Product Stock: ");
            int headpSold = headpValidate.numbersRequired("Enter Product Sold: ");


            headpData speakBase = new headpData();
            speakBase.addHeadphones(headpCode, headpName, headPrice, headpStock, headpSold);


        }

        //Read and Print Product informations
        public void headpRead()
        {
            StreamReader paytonReader = new StreamReader("HeadphonesData.txt");
            string paytonLine;
            paytonLine = paytonReader.ReadLine();

            Console.WriteLine("");
            while (paytonLine != null)
            {
                Console.WriteLine(paytonLine);
                paytonLine = paytonReader.ReadLine();
            }
            paytonReader.Close();
        }

        //Search and print product informations
        public void headpSearch()
        {
            Console.WriteLine("Enter Product Code:");
            string searchHeadp = Console.ReadLine();

            FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
            StreamReader paytonStmReader = new StreamReader(paytonStm);
            bool found = false;
            string paytonLine = paytonStmReader.ReadLine();
            string[] headphonesLineContent = paytonLine.Split('|');

            while (paytonLine != null)
            {
                headphonesLineContent = paytonLine.Split('|');
                if (headphonesLineContent[0].Equals(searchHeadp))
                {
                    found = true; break;
                }
                else
                {
                    found = false;
                }
                paytonLine = paytonStmReader.ReadLine();
            }
            paytonStmReader.Close();
            paytonStm.Close();
            if (found)
            {
                Console.WriteLine();
                Console.WriteLine(headphonesLineContent[0] + "|" + headphonesLineContent[1] + "|" + headphonesLineContent[2] + "|" + headphonesLineContent[3] + "|" + headphonesLineContent[4]);
            }
            else
            {
                Console.WriteLine("Product doesn't Exist!");
            }

        }

        //Search and update product price
        public class headphonesPriceUpdate
        {
            private static string oldPrice;
            private static string newPrice;

            //Search product
            public void headpFindUpdate()
            {
                validation codeValidate = new validation();
                int headpUp = codeValidate.numberLengthRequired("Enter code to update Price:", 1, 10);
                string searchHeadp = Convert.ToString(headpUp);

                FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                bool found = false;
                string paytonLine = paytonStmReader.ReadLine();
                string[] headpLineContent = paytonLine.Split('|');

                while (paytonLine != null)
                {
                    headpLineContent = paytonLine.Split('|');
                    if (headpLineContent[0] == searchHeadp)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStm.Close();
                paytonStmReader.Close();

                if (found)
                {
                    oldPrice = headpLineContent[2];
                    headpPUpdate();
                }
                else
                {
                    Console.WriteLine("Product doesn't Exist!");
                }

            }

            //Overwrite data
            private void headpPUpdate()
            {

                validation headpValidate = new validation();
                Console.WriteLine();
                double newHeadpPrice = headpValidate.doubleInput("Enter Product Price: ");
                newPrice = Convert.ToString(newHeadpPrice);

                FileStream paytonStm = new FileStream("HeadphonesData.txt", FileMode.Open);
                StreamReader paytonStmReader = new StreamReader(paytonStm);
                string paytonLine = paytonStmReader.ReadLine();
                string newContent = "";
                while (paytonLine != null)
                {
                    paytonLine = paytonLine.Replace(oldPrice, newPrice);
                    newContent += paytonLine + Environment.NewLine;
                    paytonLine = paytonStmReader.ReadLine();
                }

                paytonStmReader.Close();
                paytonStm.Close();
                Console.WriteLine(newContent);
                StreamWriter paytonWriter = new StreamWriter("HeadphonesData.txt");
                paytonWriter.Write(newContent);
                paytonWriter.Close();

            }
        }



        class headpData
        {
            public void addHeadphones(int hheadpCode, string hheadpName, double hheadPrice, int hheadpStock, int hheadpSold)
            {
                using (StreamWriter writer = new StreamWriter("HeadphonesData.txt", true))
                {
                    writer.WriteLine(hheadpCode + "|" + hheadpName + "|" + hheadPrice + "|" + hheadpStock + "|" + hheadpSold);
                    writer.Close();
                }
            }
        }

    }

}
