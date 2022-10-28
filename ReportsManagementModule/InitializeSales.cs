using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group11_Machine_Problem.ReportsManagementModule
{
    class InitializeSales
    {
        public void Initialize()
        {
            string path = "Sales.txt";
            string[] dailySales;
            string[] productSales;
            string[] itemReturn;
            foreach (var line in File.ReadLines(path))
            {
                string[] array = line.Split('|');

            }
        }
        

    }
}
