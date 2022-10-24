using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Reflection.Emit;

namespace MP
    class Display
    {
        private static Form loginForm;
        private static TextBox usernameTxt, passwordTxt;
        private static Button loginBtn;
        private static LinkLabel registerLinkLbl;
        public static bool isError { get; set; }

        public void DisplayLogin()
        {
            loginForm = new Form();
            loginForm.Text = "Login";
            loginForm.Width = 406;
            loginForm.Height = 224;
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.MaximizeBox = false;
            Label usernameLabel = new Label();
            usernameLabel.Text = "Username: ";
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(60, 40);
            usernameLabel.Parent = loginForm;
            Label passwordLabel = new Label();
            passwordLabel.Text = "Password: ";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(60, 90);
            passwordLabel.Parent = loginForm;
            usernameTxt = new TextBox();
            usernameTxt.Size = new Size(160, 50);
            usernameTxt.Location = new System.Drawing.Point(140, 40);
            usernameTxt.Parent = loginForm;
            passwordTxt = new TextBox();
            passwordTxt.Size = new Size(160, 50);
            passwordTxt.Location = new System.Drawing.Point(140, 90);
            passwordTxt.PasswordChar = '*';
            passwordTxt.Parent = loginForm;
            loginBtn = new Button();
            loginBtn.Text = "Login";
            loginBtn.Width = 95;
            loginBtn.Height = 25;
            loginBtn.Location = new System.Drawing.Point(270, 140);
            loginBtn.Parent = loginForm;
            loginBtn.Click += new EventHandler(loginBtn_Click);
            registerLinkLbl = new LinkLabel();
            registerLinkLbl.Text = "Register as New User";
            registerLinkLbl.Size = new Size(120, 25);
            registerLinkLbl.Location = new System.Drawing.Point(110, 145);
            registerLinkLbl.Parent = loginForm;
            registerLinkLbl.Click += new EventHandler(registerLinkLbl_Click);
            loginForm.ShowDialog();
        }

        static void loginBtn_Click(object sender, EventArgs e)
        {
            Console.Clear();

            bool isLoginSuccess = false;

            Checker check = new Checker();

            check.username = usernameTxt.Text;
            check.password = passwordTxt.Text;

            isLoginSuccess = check.CheckUserInfo();
            loginForm.Hide();

            Console.Clear();

            isError = isLoginSuccess;

            if (isLoginSuccess)
            {
                loginForm.Hide();
                Console.WriteLine("Login is successful!");
                Console.WriteLine($"Welcome, {check.username}.");
                Thread.Sleep(800);

                User loginUser = new User();
                loginUser.username = check.username;
                loginUser.SetUserInfo();
                if (loginUser.accountType == "manager")
                {
                    Manager loginManager = new Manager(loginUser.username);
                    Console.Clear();
                    loginManager.DisplayMenu();
                    isError = true;
                }
                else
                {
                    Cashier loginCashier = new Cashier(loginUser.username);
                    Console.Clear();
                    loginCashier.DisplayMenu();
                    isError = true;
                }
            }




        }

        static void registerLinkLbl_Click(object sender, EventArgs e)
        {
            loginForm.Hide();

            Console.Clear();

            User registerUser = new User();

            registerUser.CreateUser();

            Console.WriteLine("Login is successful!");
            Console.WriteLine($"Welcome, {registerUser.username}.");
            Thread.Sleep(800);

            if (registerUser.accountType == "manager")
            {
                Manager loginManager = new Manager(registerUser.username);
                Console.Clear();
                loginManager.DisplayMenu();
            }
            else
            {
                Cashier loginCashier = new Cashier(registerUser.username);
                Console.Clear();
                loginCashier.DisplayMenu();
            }

        }

    }
}
