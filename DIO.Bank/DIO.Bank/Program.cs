using DIO.Bank.Repositories;
using DIO.Bank.View;
using System;

namespace DIO.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string userOption = ViewClass.GetUserOption();

            while (userOption.ToUpper() != "X")
            {

                switch (userOption.ToUpper())
                {
                    case "1":
                        AccountRepository.ListAccounts();
                        break;
                    case "2":
                        AccountRepository.InsertAccounts();
                        break;
                    case "3":
                        AccountRepository.TransferValue();
                        break;
                    case "4":
                        AccountRepository.WithdrawValue();
                        break;
                    case "5":
                        AccountRepository.DepositValue();
                        break;
                    case "C":
                        AccountRepository.Reset();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = ViewClass.GetUserOption();
            }

            ViewClass.Finish();

        }

    }
}
