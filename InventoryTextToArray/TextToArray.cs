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
        public bool CheckInfo(string path)
        {
            try
            {
                FileStream salesReport = File.OpenRead(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unable to access files.\n");
                return false;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.\n");
                return false;
            }
            catch
            {
                Console.WriteLine("The File is Empty.");
                return false;
            }
        }

        public string[][] Transfer(string path)
        {
            bool found = CheckInfo(path);

            if (found == true)
            {
                string[][] array = new string[(File.ReadAllLines(path).Length)][];
                return array;
            }
            else
            {
                return null;
            }
        }

        public string[][] FromSales()
        {
            string path = @".\Order\Sales.txt";
            bool found = CheckInfo(path);
            string[] salesInfo;
            if (found == true)
            {
                int counter = 0;
                foreach (var line in File.ReadAllLines(path))
                {
                    salesInfo = line.Split('|');
                }


            }
            else
            {
                return null;
            }
        }
    }
}
