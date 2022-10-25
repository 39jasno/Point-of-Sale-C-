using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group11_Machine_Problem.ProductManagementModule
{
    class validation
    {
        public string InputString(string message)
        {
            string svalue;
            do
            {
                Console.Write(message);
                svalue = Console.ReadLine().ToUpper().Trim();
            } while (svalue == String.Empty);
            return svalue;
        }


        public int numberLengthRequired(String strmessage,int maximum)
        {
            int number; bool lnumber; string numlen;
            do
            {
                Console.Write(strmessage);

                lnumber = int.TryParse(Console.ReadLine(), out number);
                numlen = number.ToString();

                if (numlen.Length!=maximum)
                {
                    Console.WriteLine("\nInvalid input, must be 5 digits") ;
                }
            } while (numlen.Length != maximum);
            return number;

        }

        public int numbersRequired(string strmessage)
        {
            int score; bool lscore;
            do
            {
                Console.Write(strmessage);
                lscore = int.TryParse(Console.ReadLine(), out score);
                if (!lscore)
                {
                    Console.WriteLine("\nInvalid input");

                }
            } while (!lscore);
            return score;
        }




        public double doubleInput(String strmessage)
        {
            double inputDouble; bool boolDouble;

            do
            {
                Console.Write(strmessage);
                boolDouble = double.TryParse(Console.ReadLine(), out inputDouble);

                if (!boolDouble)
                {
                    Console.WriteLine("\nInvalid input");

                }
            } while (!boolDouble);
            return inputDouble;
        }
    }
}
