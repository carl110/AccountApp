using System;
using System.Collections.Generic;

namespace AccountApp
{
    class Program
    {
        public static List<CustomerAccount> accountList = new List<CustomerAccount>();
        static void Main(string[] args)
        {
            FileHandler.readTxtFile(accountList);
            int userInput = 0;
            do
            {
                mainMenu();
                switch (checkInput(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        addToBalance();
                        break;
                    case 2:
                        Console.Clear();
                        subtractFromBalance();
                        break;
                    case 3:
                        Console.Clear();
                        getBalance();
                        break;
                    case 4:
                        Console.Clear();
                        viewAllAccounts();
                        break;
                    case 5:
                        Console.Clear();
                        FileHandler.saveFile(accountList);
                        break;
                    default: break;
                }
            } while (userInput != 5);
        }

        static int checkInput(string input)
        {
            Console.Clear();
            int numPress = 0;
            if (int.TryParse(input, out numPress))
            {
                if (numPress > 0 && numPress < 6)
                {
                    return Convert.ToInt32(input);
                }
            }
            return numPress;
        }

        static void mainMenu()
        {
            Console.WriteLine("*******************MENU********************" +
                "\n1. Add to Balance" +
                "\n2. Subtract form balance" +
                "\n3. Get balance" +
                "\n4. Display accounts" +
                "\n5. Quit" +
                "\n*******************************************");

            Console.WriteLine("Enter menu option -\n\n");
        }
        static int surnameExists()
        {
            Console.WriteLine("Please enter surname for account...");

            string surname = Console.ReadLine();
            int exists = -1;

            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].getName() == surname)
                {
                    exists = i;
                    i = accountList.Count;
                }
            }
            return exists;
        }

        static void addToBalance()
        {
            int index = surnameExists();
            if (index != -1)
            {
                Console.WriteLine("How much do you wish to add to the account?");
                accountList[index].add(Convert.ToInt32(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("Error 001: account not found");
            }
        }

        static void subtractFromBalance()
        {
            int index = surnameExists();
            if (index != -1)
            {
                Console.WriteLine("How much do you wish to subtract from the account?");
                accountList[index].subtract(Convert.ToInt32(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("Error 001: account not found");
            }
        }

        static void getBalance()
        {
            int index = surnameExists();
            if (index != -1)
            {
               Console.WriteLine("The current balance is - " + accountList[index].getbal());
            }
            else
            {
                Console.WriteLine("Error 001: account not found");
            }
        }

        static void viewAllAccounts()
        {
            Console.WriteLine("Surname".PadRight(20) + "Account Balance");
            foreach (var account in accountList)
            {
                Console.WriteLine(account.getName().PadRight(20) + account.getbal());
            }
        }
    }
}
