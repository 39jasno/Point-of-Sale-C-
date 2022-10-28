using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Group11_Machine_Problem
{
    class User
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public string AccountType { get; private set; }
        public string DateCreated { get; private set; }
        public string Status { get; private set; }

        //create user then appends to textfile
        public void CreateUser(string strMessage = "")
        {
            Console.Clear();
            Console.WriteLine("Register User Menu\n");
            Validation validate = new Validation();
            Id = validate.GetLastID();
            Id++;
            Username = validate.ValidateUsername("Enter username: ", 1, 30);
            Password = validate.ValidateUserPassword("Enter password: ", 8, 20, Username);

            Checker check = new Checker();
            if (check.IsFileEmpty())
                AccountType = "MANAGER";
            else
                AccountType = validate.ValidateUserAccountType("Enter account type [Manager or Cashier]: ");

            var dateCreated = DateTime.Now.ToString("MM/dd/yyyy");
            Status = "ACTIVE";

            string addUserInfo = Id + "|" + Username + "|" + Password + "|" + AccountType + "|" + dateCreated + "|" + Status;
            // id[0] + usernam[1]+ password[2]+ position[3] + dayaccwas created[4]+ active or deactive status[5]

            Id++;

            string path = "Employee.txt";

            using (StreamWriter writeUserInfo = new StreamWriter(path, true))
            {
                writeUserInfo.WriteLine(addUserInfo);
                Console.WriteLine("\nUser is successfully added!");
                Console.WriteLine(strMessage);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }


        //set the the class variable based on textfile to perform user operations
        public void SetUserInfo()
        {
            string path = "Employee.txt";

            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();

                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] == Username)
                    {
                        Id = Convert.ToInt32(employeeContent[0]);
                        Password = employeeContent[2];
                        AccountType = employeeContent[3];
                        DateCreated = employeeContent[4];
                        Status = employeeContent[5];
                    }
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
        }


        //update the user file when changin its content
        public void UpdateUserFile(string newContent)
        {
            string path = "Employee.txt";

            try
            {
                FileStream employeeFile = new FileStream(path, FileMode.Truncate);
                employeeFile.Close();

                if (!(newContent.Trim() == String.Empty))
                {
                    using (StreamWriter writeUserInfo = new StreamWriter(path, true))
                    {
                        writeUserInfo.WriteLine(newContent);

                    }
                }

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
        }


        //change the password of user
        public void ChangeUserPassword()
        {
            string newPassword;

            Validation validate = new Validation();
            string path = "Employee.txt";

            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] == Username)
                    {
                        //loop unitl pass word not same as old password
                        do
                        {
                            newPassword = validate.ValidateUserPassword("Enter new Password: ", 8, 20, Username);
                            //checks if passwords is same as old password then displays error
                            if (newPassword == employeeContent[2])
                                Console.WriteLine("Invalid Input: Password cant be the same as old password!");
                        } while (newPassword == employeeContent[2]);
                        //replace old password with new password
                        employeeRecord = employeeRecord.Replace(employeeContent[2], newPassword);
                    }
                    newcontent += employeeRecord + Environment.NewLine;
                    employeeRecord = employeeReader.ReadLine();
                }
                employeeFile.Close();
                employeeReader.Close();

                UpdateUserFile(newcontent.TrimEnd());
                Console.WriteLine("Password change is successful!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
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
        }


        //activates or deactivate the account of a user
        public void ActiveOrDeactivateUserAccount(string status, string strMessage1, string strMessage2 = null)
        {
            string path = "Employee.txt";

            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');

                    if (employeeContent[1] == Username)
                    {
                        // replace old account status with new status
                        employeeRecord = employeeRecord.Replace(employeeContent[5], status);
                    }
                    newcontent += employeeRecord + Environment.NewLine;
                    employeeRecord = employeeReader.ReadLine();
                }

                employeeFile.Close();
                employeeReader.Close();

                Console.WriteLine(strMessage1 + strMessage2);
                UpdateUserFile(newcontent.TrimEnd());
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
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
        }


        //if user account is deactivated when logging in then displays prompt asking user if they want ot activate it again
        //then activate account
        public void ActivateUserAccount(string strMessage)
        {
            char choice = '0';
            do
            {
                try
                {
                    Console.Write(strMessage);
                    choice = char.Parse(Console.ReadLine().ToLower());
                    if (choice != 'y' && choice != 'n')
                        Console.WriteLine("Invalid Input: Choice must be either 'Y' or 'N'!");
                }
                catch
                {
                    Console.WriteLine("Invalid Input: Choice must be either 'Y' or 'N'!");
                }
            } while (choice != 'y' && choice != 'n');

            if (choice == 'y')
            {
                ActiveOrDeactivateUserAccount("ACTIVE", "Account is now active!", "\nTry logging in again!");

            }
        }


        //shows the expiration date of user account
        //all accounts is valid for 3 monthes
        public void ShowUserAccountExpiration()
        {
            string[] date = DateCreated.Split('/');
            int month = Convert.ToInt32(date[0]);
            int day = Convert.ToInt32(date[1]); ;
            int year = Convert.ToInt32(date[2]);

            DateTime ExpirationDate = new DateTime(year, month, day);
            ExpirationDate = ExpirationDate.AddMonths(3);
            string formatedExpirationDate = ExpirationDate.ToString("MM/dd/yyyy");
            Console.WriteLine("The expiration date of your account is {0}.", formatedExpirationDate);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //delete user from the file
        public void DeleteUserAccount()
        {
            Validation validate = new Validation();
            string path = "Employee.txt";

            try
            {
                //open file
                FileStream employeeFile = new FileStream(path, FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";

                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] != Username)
                        newcontent += employeeRecord + Environment.NewLine;
                    employeeRecord = employeeReader.ReadLine();
                }
                employeeFile.Close();
                employeeReader.Close();

                UpdateUserFile(newcontent);
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



        }

        //displays menu for user management
        public void ManageUserAccount(string strMessage)
        {
            string choice;
            do
            {
                Console.WriteLine("Manager User Management Menu\n");
                Console.WriteLine("Please select an option from the menu:\n 1 - Change Password \n 2 - Deactive your account \n 3 - Show Account Expiration \n 4 - Exit ");
                Console.Write("\nEnter choice: ");
                string userChoice = Console.ReadLine();
                choice = userChoice;

                switch (choice)
                {
                    case "1": ChangeUserPassword(); Console.Clear(); break;
                    case "2": ActiveOrDeactivateUserAccount("DEACTIVE", "User account is deactivated!"); Console.Clear(); break;
                    case "3": ShowUserAccountExpiration(); Console.Clear(); break;
                    case "4": Console.Clear(); break;
                    default: Console.WriteLine("Invalid Input: Select a choice from the options!"); Thread.Sleep(800); Console.Clear(); break;
                }
            } while (choice != "4" && choice != "2");
        }
    }
}

