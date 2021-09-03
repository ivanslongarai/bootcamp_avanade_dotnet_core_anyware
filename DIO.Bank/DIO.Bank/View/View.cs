using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.View
{
    public static class ViewClass
    {
        public static string GetUserOption()
        {
            Console.WriteLine();

            Console.WriteLine("Dio Bank as your service...");
            Console.WriteLine("Type the option please:");

            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Insert Account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Reset");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine();
            Console.WriteLine();

            return userOption;
        }

        public static void Finish()
        {
            Console.WriteLine("Thank you for your the preference by using our services..");
            Console.WriteLine();
        }

    }
}
