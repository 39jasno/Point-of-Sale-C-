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
        public static bool isError { get; set; }

        public void DisplayLogin()
        {
            //create form
            loginForm = new Form();
            loginForm.Text = "Login";
            loginForm.Width = 406;
            loginForm.Height = 224;
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.MaximizeBox = false;
            loginForm.SizeGripStyle = SizeGripStyle.Hide;
            loginForm.FormBorderStyle=FormBorderStyle.FixedDialog;


            //create label for username 
            Label usernameLabel = new Label();
            usernameLabel.Text = "Username: ";
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(60, 40);
            usernameLabel.Parent = loginForm;

            //create label for password 
            Label passwordLabel = new Label();
            passwordLabel.Text = "Password: ";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(60, 90);
            passwordLabel.Parent = loginForm;
            usernameTxt = new TextBox();

            //create textbox for username 
            usernameTxt.Size = new Size(160, 50);
            usernameTxt.BorderStyle=BorderStyle.FixedSingle;
            usernameTxt.Location = new System.Drawing.Point(140, 40);
            usernameTxt.Parent = loginForm;

            //create textbox for username 
            passwordTxt = new TextBox();
            passwordTxt.BorderStyle=BorderStyle.FixedSingle;
            passwordTxt.Size = new Size(160, 50);
            passwordTxt.Location = new System.Drawing.Point(140, 90);
            passwordTxt.PasswordChar = '*';
            passwordTxt.Parent = loginForm;

            //create login button and assign event
            loginBtn = new Button();
            loginBtn.Text = "Login";
            loginBtn.FlatStyle=FlatStyle.Flat;
            loginBtn.Width = 95;
            loginBtn.Height = 25;
            loginBtn.Location = new System.Drawing.Point(270, 140);
            loginBtn.Parent = loginForm;
            loginBtn.Click += new EventHandler(loginBtn_Click);

            loginForm.FormClosing += new FormClosingEventHandler(loginForm_Closing);

            //show the form
            loginForm.ShowDialog();
        }

        //event when pressing login button
        static void loginBtn_Click(object sender, EventArgs e)
        {
            Console.Clear();

            bool isLoginSuccess = false;

            Checker check = new Checker();

            check.username = usernameTxt.Text;
            check.password = passwordTxt.Text;

            //checks if user input in login form is correct
            isLoginSuccess = check.CheckUserInfo();
            loginForm.Hide();

            Console.Clear();

            isError = isLoginSuccess;

            //if login is successful display menu depending on their account type
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

        //windows closing event
        private void loginForm_Closing(object sender, FormClosingEventArgs e)
        {   
                isError = true;
        }




    }
}
