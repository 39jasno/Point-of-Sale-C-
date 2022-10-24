using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Group11_Machine_Problem.MainMenuRepository
{
    class Checker
    {
        public string username { get; set; }
        public string password { get; set; }

        public bool CheckUserInfo()
        {
            bool isUsernameFound = false, isPasswordCorrect = false, isAccountActive = true, isAccountExpired = false;

            if (!IsFileEmpty())
            {
                isUsernameFound = UsernameChecker();

                if (!isUsernameFound)
                    MessageBox.Show("Invalid Input: Username does not exist in employee records!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    User setUser = new User();
                    setUser.username = username;
                    setUser.SetUserInfo();

                    isPasswordCorrect = PasswordChecker(password, setUser.password);
                    isAccountActive = IsAccountActive(username);
                    isAccountExpired = IsAccountExpired(setUser.dateCreated);

                    if (!isPasswordCorrect)
                        MessageBox.Show("Invalid Input: Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (!isAccountActive)
                    {
                        MessageBox.Show("\nUser Account is not Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        User ActiveAccount = new User();
                        ActiveAccount.username = username;
                        ActiveAccount.ActivateUserAccount("Do you wish to activate your account? [Y or N]: ");
                    }
                    else
                    {
                        if (isAccountExpired)
                        {
                            MessageBox.Show("\nUser account is expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Deleting user account from database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            User deleteUser = new User();
                            deleteUser.username = username;
                            deleteUser.DeleteUserAccount();
                        }
                    }
                }

                if (isUsernameFound && isPasswordCorrect && isAccountActive && !isAccountExpired)
                    return true;
                else
                    return false;
            }
            else
            {
                MessageBox.Show("Add employees first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        public bool UsernameChecker()
        {
            bool isUsernameFound = false;
            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] == username)
                        isUsernameFound = true;
                    employeeRecord = employeeReader.ReadLine();
                }
                employeeFile.Close();
                employeeReader.Close();
            }
            catch (FileNotFoundException)
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.CreateNew);
                employeeFile.Close();
            }
            catch
            {
                Console.WriteLine("ERROR: An error has occurred!");
            }
            return isUsernameFound;
        }



        public bool PasswordChecker(string passwordInput, string password)
        {

            if (passwordInput == password)
                return true;

            return false;
        }



        public bool IsAccountActive(string username)
        {
            User accountStatus = new User();
            accountStatus.username = username;
            accountStatus.SetUserInfo();
            if (accountStatus.status != "ACTIVE")
                return false;
            return true;
        }



        public bool IsAccountExpired(string dateCreated)
        {
            string[] date = dateCreated.Split('/');
            int month = Convert.ToInt32(date[0]);
            int day = Convert.ToInt32(date[1]); ;
            int year = Convert.ToInt32(date[2]);

            DateTime ExpirationDate = new DateTime(year, month, day);
            string formatedExpirationDate = ExpirationDate.AddMonths(3).ToString("MM/dd/yyyy");

            string[] expirationDateArray = formatedExpirationDate.Split('/');
            int expirationDay = Convert.ToInt32(expirationDateArray[1]);
            int expirationMonth = Convert.ToInt32(expirationDateArray[0]);
            int expirationYear = Convert.ToInt32(expirationDateArray[2]);

            DateTime date1 = new DateTime(expirationYear, expirationMonth, expirationDay);
            TimeSpan subtractedDate = date1.Subtract(DateTime.Now);

            string[] dateDiffrence = subtractedDate.ToString().Split(':');

            if (Convert.ToDouble(dateDiffrence[0]) <= 0)
                return true;
            return false;
        }



        public bool IsFileEmpty()
        {
            bool IsFileEmpty = false;
            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
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

