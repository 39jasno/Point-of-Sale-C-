using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Group11_Machine_Problem
{
    //checker class checks if user info is correct when logging in
    class Checker
    {
        public string Username { get; set; }
        public string Password { private get; set; }

        //checks user info when logging in if valid and correct
        public bool CheckUserInfo()
        {
            bool isPasswordCorrect = false, isAccountActive = true, isAccountExpired = false;

            //if file is empty then displays error then ask user to add a manager account
            if (!IsFileEmpty())
            {
                bool isUsernameFound = UsernameChecker();

                //if username not in file displays error
                if (!isUsernameFound)
                    MessageBox.Show("Invalid Input: Username does not exist in employee records!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    User setUser = new User
                    {
                        Username = Username
                    };
                    setUser.SetUserInfo();

                    //checks password, account status, and if account is expired
                    isPasswordCorrect = PasswordChecker(Password, setUser.Password);
                    isAccountActive = IsAccountActive(Username);
                    isAccountExpired = IsAccountExpired(setUser.DateCreated);

                    //if password is incorrect displays error
                    if (!isPasswordCorrect)
                        MessageBox.Show("Invalid Input: Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //if accounts is not active display error then ask user if they want to activate account
                    else if (!isAccountActive)
                    {
                        MessageBox.Show("\nUser Account is not Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Display.loginForm.Hide();
                        User ActiveAccount = new User
                        {
                            Username = Username
                        };
                        ActiveAccount.ActivateUserAccount("Do you wish to activate your account? [Y or N]: ");
                    }
                    else
                    {
                        //if account is expired display error then deletes user info from textfile
                        if (isAccountExpired)
                        {
                            MessageBox.Show("\nUser account is expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Deleting user account from database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //deletes the user from texfile
                            User deleteUser = new User
                            {
                                Username = Username
                            };
                            deleteUser.DeleteUserAccount();
                        }
                    }
                }

                //if all info is valid and correct return true
                if (isUsernameFound && isPasswordCorrect && isAccountActive && !isAccountExpired)
                    return true;
                else
                    return false;
            }
            else
            {
                //display error asking user to add manager account
                MessageBox.Show("Add a Manager Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Display.loginForm.Hide();
                //adds manager account
                User addManager = new User();
                addManager.CreateUser("Try logging in again!");
                return false;
            }
        }


        //chceks if usernames if in textfile
        public bool UsernameChecker()
        {
            string path = @".\Employee\Employee.txt";

            bool isUsernameFound = false;
            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    //return true if username is found
                    if (employeeContent[1] == Username)
                        isUsernameFound = true;
                    employeeRecord = employeeReader.ReadLine();
                }
                employeeFile.Close();
                employeeReader.Close();
            }
            catch (FileNotFoundException)
            {
                FileStream employeeFile = new FileStream(path, FileMode.CreateNew);
                employeeFile.Close();
            }
            catch
            {
                Console.WriteLine("ERROR: An error has occurred!");
            }
            return isUsernameFound;
        }


        //check is the password is correct
        public bool PasswordChecker(string passwordInput, string password)
        {

            if (passwordInput == password)
                return true;

            return false;
        }


        //check if account status is active
        public bool IsAccountActive(string username)
        {
            User accountStatus = new User
            {
                Username = username
            };
            accountStatus.SetUserInfo();
            if (accountStatus.Status != "ACTIVE")
                return false;
            return true;
        }


        //checks if account is expired
        //all acounts is valid for 3 months
        public bool IsAccountExpired(string dateCreated)
        {
            //gets date account was created from textfile
            string[] date = dateCreated.Split('/');
            int month = Convert.ToInt32(date[0]);
            int day = Convert.ToInt32(date[1]); ;
            int year = Convert.ToInt32(date[2]);

            DateTime ExpirationDate = new DateTime(year, month, day);
            //adds 3 month to date account was created
            string formatedExpirationDate = ExpirationDate.AddMonths(3).ToString("MM/dd/yyyy");

            string[] expirationDateArray = formatedExpirationDate.Split('/');
            int expirationDay = Convert.ToInt32(expirationDateArray[1]);
            int expirationMonth = Convert.ToInt32(expirationDateArray[0]);
            int expirationYear = Convert.ToInt32(expirationDateArray[2]);

            DateTime date1 = new DateTime(expirationYear, expirationMonth, expirationDay);
            //subracts the date of expiration of account from todays date
            TimeSpan subtractedDate = date1.Subtract(DateTime.Now);

            string[] dateDiffrence = subtractedDate.ToString().Split(':');

            //if the diffrence between date of expiration of account and todays date is less than 0 then account is expired
            //return true if account is expired
            if (Convert.ToDouble(dateDiffrence[0]) <= 0)
                return true;
            return false;
        }


        //checks if file is empty
        public bool IsFileEmpty()
        {
            string path = @".\Employee\Employee.txt";
            bool IsFileEmpty = false;
            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();

                if (employeeRecord == null || employeeRecord.Trim() == string.Empty)
                {
                    IsFileEmpty = true;
                }
                employeeFile.Close();
                employeeReader.Close();
            }
            catch (FileNotFoundException)
            {
                IsFileEmpty = true;
            }
            catch
            {
                Console.WriteLine("ERROR: An error has occurred!");
            }


            return IsFileEmpty;
        }

    }
}

