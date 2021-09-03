using DIO.Bank.Entities.Enums;
using System;

namespace DIO.Bank.Entities
{
    public class Account
    {
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private AccountType AccountType { get; set; }

        public Account(string name, double balance, double credit, AccountType accountType)
        {
            Name = name;
            Balance = balance;
            Credit = credit;
            AccountType = accountType;
        }

        public bool Withdraw(double value)
        {
            if (value > (Balance + Credit))
            {
                Console.WriteLine($"Saldo disponível insuficiente para saque. Saldo disponível para {Name} é de: {Balance + Credit}");
                return false;
            }

            Balance -= value;
            Console.WriteLine($"Saldo disponível atual da conta de {Name} é de {Balance + Credit}");
            return true;
        }

        public bool Deposit(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine($"Valor inválido para depósito. Valor recebido: {value}");
                return false;
            }

            Balance += value;
            Console.WriteLine($"Saldo disponível atual da conta de {Name} é de {Balance + Credit}");
            return true;
        }

        public bool Transfer(double value, Account destinyAccount)
        {
            if (Withdraw(value))
            {
                if (!destinyAccount.Deposit(value))
                {
                    Deposit(value);
                    return false;
                }
            }
            else
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Balance: {Balance}, Credit: {Credit}, AccountType: {AccountType}";
        }

    }
}
