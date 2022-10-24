using System;
using Group11_Machine_Problem.MainMenuRepository;

namespace Group11_Machine_Problem
{
    public class PoS
    {
        static void Main(string[] args)
        {
            
            //eto yung ginawa ko na login form
            DialogResult tryAgain = DialogResult.No;
            do
            {
                Display LoginDisplay = new Display();
                LoginDisplay.DisplayLogin();
  
                if(Display.isError)
                    tryAgain = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            } while (tryAgain != DialogResult.Yes);

            Console.ReadKey();
            
            
            
            
            
            MainMenu menu = new MainMenu();
            Reports sales = new Reports();  
            bool programLoop = true;
            while (programLoop)
            {
                string user = Console.ReadLine();
                Console.WriteLine("MAINMENU");
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
            }
        }
    }
}
