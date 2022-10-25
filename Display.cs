using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;

namespace Group11_Machine_Problem
{
    class Display
    {
        public static Form loginForm;
        private static TextBox usernameTxt, passwordTxt;
        private static Button loginBtn;
        public static bool IsError { get; set; }

        public void DisplayLogin()
        {
            //create form
            loginForm = new Form
            {
                Text = "Login",
                Width = 406,
                Height = 224,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                SizeGripStyle = SizeGripStyle.Hide,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };


            //create label for username 
            Label usernameLabel = new Label
            {
                Text = "Username: ",
                AutoSize = true,
                Location = new System.Drawing.Point(60, 40),
                Parent = loginForm
            };

            //create label for password 
            Label passwordLabel = new Label
            {
                Text = "Password: ",
                AutoSize = true,
                Location = new System.Drawing.Point(60, 90),
                Parent = loginForm
            };
            usernameTxt = new TextBox
            {

                //create textbox for username 
                Size = new Size(160, 50),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new System.Drawing.Point(140, 40),
                Parent = loginForm
            };

            //create textbox for username 
            passwordTxt = new TextBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(160, 50),
                Location = new System.Drawing.Point(140, 90),
                PasswordChar = '*',
                Parent = loginForm
            };

            //create login button and assign event
            loginBtn = new Button
            {
                Text = "Login",
                FlatStyle = FlatStyle.Flat,
                Width = 95,
                Height = 25,
                Location = new System.Drawing.Point(270, 140),
                Parent = loginForm
            };
            loginBtn.Click += new EventHandler(LoginBtn_Click);

            loginForm.FormClosing += new FormClosingEventHandler(LoginForm_Closing);

            //show the form
            loginForm.ShowDialog();
        }

        //event when pressing login button
        static void LoginBtn_Click(object sender, EventArgs e)
        {
            Console.Clear();
            Checker check = new Checker
            {
                Username = usernameTxt.Text,
                Password = passwordTxt.Text
            };

            //checks if user input in login form is correct
            bool isLoginSuccess = check.CheckUserInfo();
            loginForm.Hide();

            Console.Clear();

            IsError = isLoginSuccess;

            //if login is successful display menu depending on their account type
            if (isLoginSuccess)
            {
                loginForm.Hide();
                Console.WriteLine("Login is successful!");
                Console.WriteLine($"Welcome, {check.Username}.");
                Thread.Sleep(800);

                User loginUser = new User
                {
                    Username = check.Username
                };
                loginUser.SetUserInfo();
                if (loginUser.AccountType == "manager")
                {
                    Manager loginManager = new Manager(loginUser.Username);
                    Console.Clear();
                    loginManager.DisplayMenu();
                    IsError = true;
                }
                else
                {
                    Cashier loginCashier = new Cashier(loginUser.Username);
                    Console.Clear();
                    loginCashier.DisplayMenu();
                    IsError = true;
                }
            }

        }

        //windows closing event
        private void LoginForm_Closing(object sender, FormClosingEventArgs e)
        {   
                IsError = true;
        }




    }
}
