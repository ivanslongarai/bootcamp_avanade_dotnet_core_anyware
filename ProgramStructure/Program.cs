using System;
using ProgramStructure.Examples;

namespace ProgramStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var oStack = new Stack();
            Console.WriteLine($"");
            Console.WriteLine($"Starting...");
            Console.WriteLine($"===================================");
            Console.WriteLine($"Inserted item {oStack.StackUp(001)}");
            Console.WriteLine($"Inserted item {oStack.StackUp(010)}");
            Console.WriteLine($"Inserted item {oStack.StackUp(100)}");
            Console.WriteLine($"===================================");
            Console.WriteLine($"Removed item {oStack.Unstack()}");
            Console.WriteLine($"Removed item {oStack.Unstack()}");
            Console.WriteLine($"Removed item {oStack.Unstack()}");
            Console.WriteLine($"===================================");
            Console.WriteLine($"Finished.");
            Console.WriteLine($"");
        }
    }
}
