using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group11_Machine_Problem
{ 
    class Validation
    {
        public string ValidateUserPassword(string strMessage, int passMin, int passMax, string username)
        {
            string password; bool hasValidCharacters = true;
            do
            {
                Console.Write(strMessage);
                password = Console.ReadLine();

                if (username == password)
                    Console.WriteLine("Invalid Input: Password input must not be the same a username!");
                else if (password.Length < passMin)
                    Console.WriteLine("Invalid Input: Password length must be greater than or equal to {0}!", passMin);
                else if (password.Length > passMax)
                    Console.WriteLine("Invalid Input: Password length must be less than or equal to {0}!", passMax);
                else
                    hasValidCharacters = CharacterChecker(password, 1, 1, 1, 1);

            } while (!(password.Length >= passMin && password.Length <= passMax) || hasValidCharacters || username == password);

            return password;
        }
        public bool CharacterChecker(string password, int lowerMin, int upperMin, int digitMin, int specialMin)
        {
            int digitCounter = 0, lowerCounter = 0, upperCounter = 0, specialCounter = 0;
            char[] specialCharacters = "!@#$%^&*?_~-().,".ToCharArray();

            foreach (char i in password)
            {
                if (char.IsLower(i))
                    lowerCounter += 1;
                else if (char.IsUpper(i))
                    upperCounter += 1;
                else if (char.IsDigit(i))
                    digitCounter += 1;
                else if (specialCharacters.Contains(i))
                    specialCounter += 1;
            }

            if (lowerCounter < lowerMin)
                Console.WriteLine("Invalid Input: Password must contain atleast {0} lowercase characters!", lowerMin);
            else if (upperCounter < upperMin)
                Console.WriteLine("Invalid Input: Password must contain atleast {0} uppercase characters!", upperMin);
            else if (digitCounter < digitMin)
                Console.WriteLine("Invalid Input: Password must contain atleast {0} digit characters!", digitMin);
            else if (specialCounter < specialMin)
                Console.WriteLine("Invalid Input: Password must contain atleast {0} special characters! (!@#$%^&*?_~-().,)", specialMin);

            if (lowerCounter >= lowerMin && upperCounter >= upperMin && digitCounter >= digitMin && specialCounter >= specialMin)
                return false;

            return true;
        }
        public string ValidateUsername(string strMessage, int nameMin, int nameMax)
        {
            string username; bool doesAccountExist = false;

            do
            {
                Console.Write(strMessage);
                username = Console.ReadLine().Trim();

                doesAccountExist = DoesAccountExist(username);

                if (doesAccountExist)
                    Console.WriteLine("Invalid Input: Username is already taken!");
                else
                {
                    if (username.Length < nameMin)
                        Console.WriteLine("Invalid Input: Name length must be greater than {0}!", nameMin);
                    else if (username.Length > nameMax)
                        Console.WriteLine("Invalid Input: Name length must be less than {0}!", nameMax);
                }
            } while (username == string.Empty || !(username.Length >= nameMin && username.Length <= nameMax) || doesAccountExist);

            return username;
        }
        public int GetLastID()
        {
            int ID = 999999;
            Checker check = new Checker();

            try
            {
                FileStream employeeFile = new FileStream("employee.txt", FileMode.Open);
                StreamReader employeeReader = new StreamReader(employeeFile);
                string employeeRecord = employeeReader.ReadLine();
                while (employeeRecord != null)
                {
                    string[] employeeContent = employeeRecord.Split('|');
                    ID = Convert.ToInt32(employeeContent[0]);
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

            return ID;
        }
        public bool DoesAccountExist(string username)
        {
            bool doesAccountExist = false;
            Checker check = new Checker();
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
                        doesAccountExist = true;
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

            return doesAccountExist;
        }
        public string ValidateUserAccountType(string strMessage)
        {
            string accountType;

            do
            {
                Console.Write(strMessage);
                accountType = Console.ReadLine().ToLower();
                if (accountType != "manager" && accountType != "cashier")
                    Console.WriteLine("Invalid Input: Account type must be either manager or cashier!");
            } while (!(accountType == "manager" || accountType == "cashier"));

            return accountType;
        }
    }
}


