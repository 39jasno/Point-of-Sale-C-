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
        public string[][] dailySales { get; set; }
        public string[][] productSales { get; set; }
        public string[][] returnItems { get; set; } 
        public void Initialize()
        {
            string path = "Sales.txt";

            foreach (var line in File.ReadLines(path))
            {
                string[] array = line.Split('|');
                dailySales = dSales(array, path);
                productSales = pSales(array, path);
                //itemReturn = iReturn(array, path);
            }
            writeInitalize(dailySales, productSales);
        }
        public string[][] dSales(string[] array, string path)
        {
            string[][] dailySales = new string[File.ReadAllLines(path).Length][];
            int counter = 0;
            foreach (var line in File.ReadLines(path))
            {
                string[] info = line.Split('|');

                dailySales[counter] = new string[2] { info[4], info[5] };
                counter++;
            }

            return dailySales;
        }
        public string[][] pSales(string[] array, string path)
        {
            string[][] productSales = new string[File.ReadAllLines(path).Length][];
            int counter = 0;
            foreach (var line in File.ReadLines(path))
            {
                string[] info = line.Split('|');
                productSales[counter] = new string[3] { info[1], info[2],info[3] };
                counter++;
            }
            return productSales;
        }
        public string[][] iReturn(string[] array, string path)
        {
            string[][] itemReturn = new string[File.ReadAllLines(path).Length][];
            int counter = 0;
            foreach (var line in File.ReadLines(path))
            {
                string[] info = line.Split('|');
                itemReturn[counter] = new string[2] { info[1], info[2] };
                counter++;
            }

            return itemReturn;
        }

        private void writeInitalize(string[][] dailySales, string[][] productSales)
        {
            Console.Clear();
            FileStream dsales = File.Open("dailySales.txt", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(dsales))
            {
                for (int x = 0; x < dailySales.Length; x++)
                {
                    writer.WriteLine(dailySales[x][0] + "|" + dailySales[x][1]);
                }
                writer.Close();

            }
            FileStream psales = File.Open("productSales.txt", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(psales))
            {
                for (int x = 0; x < productSales.Length; x++)
                {
                    writer.WriteLine(productSales[x][0] + "|" + productSales[x][1] + "|" + productSales[x][2]);
                }
                writer.Close();
            }
            dsales.Close();
            psales.Close();



        }
    }
}
