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
        public bool checkInfo(string path)
        {
            try
            {
                FileStream salesReport = File.OpenRead(path);
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
            bool found = checkInfo(path);

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
    }
}
