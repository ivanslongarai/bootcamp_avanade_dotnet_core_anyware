using DIO.Bank.Entities;
using DIO.Bank.Entities.Enums;
using System;
using System.Collections.Generic;

namespace DIO.Bank.Repositories
{
    static public class AccountRepository
    {
        static List<Account> listAccounts = new List<Account>();

        static public void ListAccounts()
        {

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("There are no accounts to list");
                Console.WriteLine();
                return;
            }

            int index = 0;

            foreach (var account in listAccounts)
            {
                Console.WriteLine($"#{index}, {account}");
                index++;
            }

            Console.WriteLine();
        }

        static public void InsertAccounts()
        {
            Console.WriteLine("Inserting a new Account");

            Console.Write("Type the AccountType 1 for Individual and 2 for Legal: ");
            int typeAcount = int.Parse(Console.ReadLine());

            Console.Write("Type the Client's name: ");
            string clientName = Console.ReadLine();

            Console.Write("Type the Initial Balance: ");
            double initialBalance = double.Parse(Console.ReadLine());

            Console.Write("Type the Initial Credit: ");
            double initialCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(clientName, initialBalance, initialCredit, (AccountType)typeAcount);

            Console.WriteLine();
            Console.WriteLine("Created account: ");
            Console.WriteLine(newAccount);

            Console.WriteLine();
            listAccounts.Add(newAccount);
            Console.WriteLine();

        }

        public static bool WithdrawValue()
        {
            ListAccounts();

            Console.Write("Type the Account's Index for Withdraw: ");
            int index = int.Parse(Console.ReadLine());

            Console.Write("Type the Withdraw's value: ");
            double value = int.Parse(Console.ReadLine());

            return listAccounts[index].Withdraw(value);
        }

        public static bool DepositValue()
        {
            ListAccounts();

            Console.Write("Type the Account's Index for Deposit: ");
            int index = int.Parse(Console.ReadLine());

            Console.Write("Type the Deposit's value: ");
            double value = int.Parse(Console.ReadLine());

            return listAccounts[index].Deposit(value);
        }

        public static void Reset()
        {
            Console.Clear();
            listAccounts.Clear();
        }

        public static bool TransferValue()
        {
            ListAccounts();

            Console.Write("Type the Origin's Account index: ");
            int originIndex = int.Parse(Console.ReadLine());
            Console.Write("Type the Destiny's Account index: ");
            int destinyIndex = int.Parse(Console.ReadLine());

            Console.Write("Type the Transfer's value: ");
            double value = int.Parse(Console.ReadLine());

            return listAccounts[originIndex].Transfer(value, listAccounts[destinyIndex]);

        }
    }
}
