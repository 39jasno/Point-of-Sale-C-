using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OrderManagementSystemModule
{
    class Keyboard
    {
        public Keyboard()
        {
            int qty;

            Console.WriteLine("1. KEYCHRON Q1" + " Price: " + 8990);
            Console.WriteLine("2. GMMK PRO" + " Price: " + 8095);
            Console.WriteLine("3. GMMK 2" + " Price: " + 5990);
            int Keychron = 8990;
            int gmmkPro = 8095;
            int gmmk2 = 5990;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                Keychron *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", Keychron);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                gmmkPro *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", gmmkPro);
            }

            else if (keychoice == 3)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                gmmk2 *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", gmmk2);
            }

            else
            {
                MessageBox.Show("Invalid");
            }

        }
    }

    class Monitor
    {
        public Monitor()
        {
            int qty;
            Console.WriteLine("1. ICON 23 INCH MONITOR" + " Price: " + 2599);
            Console.WriteLine("2. AIODIY 24 INCH MONITOR" + " Price: " + 3999);
            int icon = 2599;
            int aiodiy = 2599;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                icon *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", icon);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                aiodiy *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", aiodiy);
            }

            else
            {
                MessageBox.Show("Invalid");
            }

        }
    }

    class Mouse
    {
        public Mouse()
        {
            int qty;
            Console.WriteLine("1. RAZER VIPER MINI" + " Price " + 1050);
            Console.WriteLine("2. LOGITECH G203" + " Price: " + 1099);

            int razer = 1050;
            int logitech = 1099;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                razer *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", razer);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                logitech *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", logitech);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }

    class Speaker
    {
        public Speaker()
        {
            int qty;
            Console.WriteLine("1. RED DRAGON GS550 ORPHEUS" + " Price: " + 725);
            Console.WriteLine("2. FANTECH GS205" + " Price: " + 550);

            int redDragon = 725;
            int fantech = 550;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                redDragon *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", redDragon);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                fantech *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", fantech);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }

    class Headphone
    {
        public Headphone()
        {
            int qty;
            Console.WriteLine("1. HYPERX CLOUD STINGER" + " Price: " + 1790);
            Console.WriteLine("2. ONIKUMA K19" + " Price: " + 550);

            int hyperxCloud = 1790;
            int onikuma = 550;

            int keychoice = Convert.ToInt32(Console.ReadLine());
            if (keychoice == 1)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                hyperxCloud *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", hyperxCloud);
            }

            else if (keychoice == 2)
            {
                Console.WriteLine("QTY: ");
                qty = Convert.ToInt32(Console.ReadLine());
                onikuma *= qty;
                Console.WriteLine("total price of chosen keyboard is: {0:N2} ", onikuma);
            }

            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
