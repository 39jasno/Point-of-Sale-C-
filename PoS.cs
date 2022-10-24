using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
