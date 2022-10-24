﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Group11_Machine_Problem.MainMenuRepository
{
    class User
    {
        public int id { get; private set; }
        public string username { get; set; }
        public string password { get; private set; }
        public string accountType { get; private set; }
        public string dateCreated { get; private set; }
        public string status { get; private set; }

        public void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Register User Menu\n");
            Validation validate = new Validation();
            id = validate.GetLastID();
            id++;
            username = validate.ValidateUsername("Enter username: ", 1, 30);
            password = validate.ValidateUserPassword("Enter password: ", 8, 20, username);
            accountType = validate.ValidateUserAccountType("Enter account type [Manager or Cashier]: ");
            var dateCreated = DateTime.Now.ToString("MM/dd/yyyy");
            status = "ACTIVE";

            string addUserInfo = id + "|" + username + "|" + password + "|" + accountType + "|" + dateCreated + "|" + status;
            // id[0] + usernam[1]+ password[2]+ position[3] + dayaccwas created[4]+ active or deactive status[5]

            id++;
            using (StreamWriter writeUserInfo = new StreamWriter("employee.txt", true))
            {
                writeUserInfo.WriteLine(addUserInfo);
                Console.WriteLine("\nUser is successfully added!");
                Thread.Sleep(800);
                Console.Clear();
            }
        }



        public void SetUserInfo()
        {
            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();

                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] == username)
                    {
                        id = Convert.ToInt32(employeeContent[0]);
                        password = employeeContent[2];
                        accountType = employeeContent[3];
                        dateCreated = employeeContent[4];
                        status = employeeContent[5];
                    }
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
        }



        public void UpdateUserFile(string newContent)
        {
            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Truncate);
                employeeFile.Close();

                if (!(newContent.Trim() == String.Empty))
                {
                    using (StreamWriter writeUserInfo = new StreamWriter("employee.txt", true))
                    {
                        writeUserInfo.WriteLine(newContent);

                    }
                }

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
        }



        public void ChangeUserPassword()
        {
            string newPassword;

            Validation validate = new Validation();

            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] == username)
                    {
                        do
                        {
                            newPassword = validate.ValidateUserPassword("Enter new Password: ", 8, 20, username);
                            if (newPassword == employeeContent[2])
                                Console.WriteLine("Invalid Input: Password cant be the same as old password!");
                        } while (newPassword == employeeContent[2]);
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
                FileStream employeeFile = new FileStream("employee.txt", FileMode.CreateNew);
                employeeFile.Close();
            }
            catch
            {
                Console.WriteLine("ERROR: An error has occurred!");
            }
        }



        public void ActiveOrDeactivateUserAccount(string status, string strMessage1, string strMessage2 = null)
        {
            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');

                    if (employeeContent[1] == username)
                    {
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
                FileStream employeeFile = new FileStream("employee.txt", FileMode.CreateNew);
                employeeFile.Close();
            }
            catch
            {
                Console.WriteLine("ERROR: An error has occurred!");
            }
        }



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



        public void ShowUserAccountExpiration()
        {
            string[] date = dateCreated.Split('/');
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

        public void DeleteUserAccount()
        {
            Validation validate = new Validation();

            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                string newcontent = "";

                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    if (employeeContent[1] != username)
                        newcontent += employeeRecord + Environment.NewLine;
                    employeeRecord = employeeReader.ReadLine();
                }
                employeeFile.Close();
                employeeReader.Close();

                UpdateUserFile(newcontent);
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



        }

        public void ManageUserAccount(string strMessage)
        {
            string choice = "0";

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

