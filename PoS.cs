using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group11_Machine_Problem.MainMenus;

namespace Group11_Machine_Problem
{
    public class PoS
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            Reports sales = new Reports();
            string user = Console.ReadLine();
            if (user == "1")
            {
                menu.adminMainMenu();
                string choice = Console.ReadLine();
                if (choice == "3")
                {
                    sales.reports();
                }
            }
            else if (user == "2")
            {
                menu.employeeMainMenu();
            }
            Console.WriteLine("MAINMENU");

        }
    }
}
