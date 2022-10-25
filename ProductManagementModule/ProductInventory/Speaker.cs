using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Group11_Machine_Problem.ProductManagementModule;

namespace Group11_Machine_Problem
{
    class ProductSpeaker
    {
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
}
