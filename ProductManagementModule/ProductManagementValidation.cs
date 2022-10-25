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
