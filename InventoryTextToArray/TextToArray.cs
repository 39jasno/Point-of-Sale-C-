using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group11_Machine_Problem.ReportsManagementModule
{
    public class Inventory
    {
        public bool checkInfo()
        {
            try
            {
                FileStream salesReport = File.OpenRead("DailySales.txt");
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\nUnable to access files.\n");
                return false;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nFile not found.\n");
                return false;
            }
            catch
            {
                Console.WriteLine("The File is Empty.");
                return false;
            }
        }

        public string[][] transfer(string path)
        {
            bool found = checkInfo();

            if (found == true)
            {
                string[][] array = new string[(File.ReadAllLines(path).Length)][];

                int counter = 0;
                foreach (var line in File.ReadLines(path))
                {
                    string[] info = line.Split('|');
                    array[counter] = new string[2] { info[0], info[1] };
                    counter++;
                }
                return array;
            }
            else
            {
                return null;
            }
            /*{
                string[] stringArray = File.ReadAllLines(path);
                string[] array = new string[stringArray.Length];
                int counter = 0;
                foreach (string example in stringArray)
                {
                    array[counter] = example;
                    counter++;
                }
                return array;
            }
            else
            {
                return null;
            }*/
        }
    }
}
