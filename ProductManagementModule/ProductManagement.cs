﻿using System;
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
        static void Introduction()
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
                Introduction();

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
                            product.Write("KeyboardData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "2")
                        {
                            product.Write("MouseData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "3")
                        {
                            product.Write("MonitorData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "4")
                        {
                            product.Write("SpeakersData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "5")
                        {
                            product.Write("HeadphonesData.txt");
                            Console.WriteLine("Data successfully inputted");

                        }

                        else if (AmenuChoice.Trim() == "6")
                        {
                            Console.Clear();
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Invalid input");

                        }


                    } while (menuChoice!= "6");

                }

                else if (menuChoice.Trim() == "2")
                {
                    string BmenuChoice;
                    do
                    {

                        Console.Clear();
                        Console.Write("Display Product Information\n" +
                            "\n1 - Keyboard " +
                            "\n2 - Mouse " +
                            "\n3 - Monitor " +
                            "\n4 - Speakers " +
                            "\n5 - Headphones" +
                            "\n6 - Return" +
                            "\n\nInput choice: ");

                        BmenuChoice = Console.ReadLine();

                        if (BmenuChoice.Trim() == "1")
                        {
                            product.Read("KeyboardData.txt");

                        }

                        else if (BmenuChoice.Trim() == "2")
                        {
                            product.Read("MouseData.txt");

                        }

                        else if (BmenuChoice.Trim() == "3")
                        {
                            product.Read("MonitorData.txt");

                        }

                        else if (BmenuChoice.Trim() == "4")
                        {
                            product.Read("SpeakersData.txt");

                        }

                        else if (BmenuChoice.Trim() == "5")
                        {
                            product.Read("HeadphonesData.txt");

                        }

                        else if (BmenuChoice.Trim() == "6")
                        {
                            Console.Clear();
                            break;

                        }

                        else
                        {
                            Console.WriteLine("Invalid input");

                        }

                    } while (BmenuChoice!="6");

                }

                else if (menuChoice.Trim() == "3")
                {
                    string CmenuChoice;
                    ProductManagementOperations.keyboardPriceUpdate update = new ProductManagementOperations.keyboardPriceUpdate();
                    do
                    {
                        Console.Clear();
                        Console.Write("Update Price\n" +
                                "\n1 - Keyboard " +
                                "\n2 - Mouse " +
                                "\n3 - Monitor " +
                                "\n4 - Speakers " +
                                "\n5 - Headphones" +
                                "\n6 - Return" +
                                "\n\nInput choice: ");

                        CmenuChoice = Console.ReadLine();

                        if (CmenuChoice.Trim() == "1")
                        {
                            update.FindUpdate("KeyboardData.txt");

                        }

                        else if (CmenuChoice.Trim() == "2")
                        {
                            update.FindUpdate("MouseData.txt");

                        }

                        else if (CmenuChoice.Trim() == "3")
                        {
                            update.FindUpdate("MonitorData.txt");

                        }

                        else if (CmenuChoice.Trim() == "4")
                        {
                            update.FindUpdate("SpeakersData.txt");

                        }

                        else if (CmenuChoice.Trim() == "5")
                        {
                            update.FindUpdate("HeadphonesData.txt");

                        }

                        else if (CmenuChoice.Trim() == "6")
                        {
                            Console.Clear();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid input");

                        }

                    } while (CmenuChoice != "6") ;

                }

                else if (menuChoice.Trim() == "4")
                {
                    string DmenuChoice = "";
                    do
                    {
                        Console.Clear();
                        try
                        {

                            Console.Write("Search For Product Information\n" +
                                "\n1 - Keyboard" +
                                "\n2 - Mouse" +
                                "\n3 - Monitor" +
                                "\n4 - Speakers" +
                                "\n5 - Headphones" +
                                "\n6 - Return" +
                                "\n\nInput choice: ");

                            DmenuChoice = Console.ReadLine();

                            if (DmenuChoice.Trim() == "1")
                            {
                                product.Search("KeyboardData.txt");

                            }

                            else if (DmenuChoice.Trim() == "2")
                            {
                                product.Search("MouseData.txt");

                            }

                            else if (DmenuChoice.Trim() == "3")
                            {
                                product.Search("MonitorData.txt");

                            }

                            else if (DmenuChoice.Trim() == "4")
                            {
                                product.Search("SpeakersData.txt");

                            }

                            else if (DmenuChoice.Trim() == "5")
                            {
                                product.Search("HeadphonesData.txt");

                            }
                            else if (DmenuChoice.ToUpper() == "6")
                            {
                                Console.Clear();
                                break;

                            }

                            else
                            {
                                Console.WriteLine("Invalid input");

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
                    Console.WriteLine("Invalid input");

                }

            } while (menuChoice!= "5");
        }

    }

}
