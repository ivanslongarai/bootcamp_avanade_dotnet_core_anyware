using System;

namespace Instructions
{
    class Program
    {
        static void Main(string[] args)
        {
            Declarations();

            string[] arrayIf = { "1", "2", "3" };
            IntructionIf(arrayIf);

            string[] arraySwitch = { "1", "2", "3", "4" };
            IntructionSwitch(arraySwitch);

            string[] arrayWhile = { "1", "2", "3", "4", "5" };
            IntructionWhile(arrayWhile);

            InstructionDo();

            string[] arrayFor = { "1", "2", "3", "4", "5", "6" };
            InstructionFor(arrayFor);

            string[] arrayEach = { "1", "2", "3", "4", "5", "6", "7" };
            InstructionForeach(arrayEach);

            InstructionBreak();

            string[] arrayContinue = { "/1", "2", "/3", "4", "5", "6", "7" };
            InstructionContinue(arrayContinue);

            InstructionReturn();

            string[] arrayTryCatchFinallyThrow = { "100", "10" };
            InstructionTryCatchFinallyThrow(arrayTryCatchFinallyThrow);

            InstructionUsing();
        }

        static void Declarations()
        {
            int varIntegerA;
            int varIntegerB = 2, varIntegerC = 3;
            const int constIntegerA = 4;
            varIntegerA = 1;
            Console.WriteLine($"{varIntegerA + varIntegerB + varIntegerC + constIntegerA}");
        }

        static void IntructionIf(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No args...");
            }
            else if (args.Length == 1)
            {
                Console.WriteLine("One argument");
            }
            else
            {
                Console.WriteLine($"{args.Length} arguments");
            }
        }

        static void IntructionSwitch(string[] args)
        {

            int numberOfArgs = args.Length;

            switch (numberOfArgs)
            {
                case 0:
                    {
                        Console.WriteLine("No args...");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("One argument");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"{args.Length} arguments");
                        break;
                    }
            }

        }

        static void IntructionWhile(string[] args)
        {
            int i = 0;
            while (i < args.Length)
            {
                Console.WriteLine(args[i]);
                i++;
            }
        }

        static void InstructionDo()
        {
            string text;
            do
            {
                Console.WriteLine("Type something to continue or empty to exit...");
                text = Console.ReadLine();
                Console.WriteLine($"Typed text with 'do': {text}");
            } while (!string.IsNullOrEmpty(text));

        }

        static void InstructionFor(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }

        static void InstructionForeach(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        static void InstructionBreak()
        {
            while (true)
            {
                Console.WriteLine("Type something to continue or empty to exit...");
                string sTypedText = Console.ReadLine();
                if (string.IsNullOrEmpty(sTypedText))
                    break;
                Console.WriteLine($"Typed text with Break: {sTypedText}");
            }
        }

        static void InstructionContinue(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("/"))
                {
                    Console.WriteLine($"Skipped : {args[i]}");
                    continue;
                }
                Console.WriteLine(args[i]);
            }
        }

        static void InstructionReturn()
        {
            int Sum(int value1, int value2)
            {
                return value1 + value2;
            }
            Console.WriteLine($"Result of Sum (1+2) : {Sum(1, 2)}");
            Console.WriteLine($"Result of Sum (3+4) : {Sum(3, 4)}");
            Console.WriteLine($"Result of Sum (5+6) : {Sum(5, 6)}");
        }

        static void InstructionTryCatchFinallyThrow(string[] args)
        {
            double Divide(double value, double divideBy)
            {
                if (divideBy == 0)
                    throw new DivideByZeroException();
                return value / divideBy;
            }
            try
            {
                if (args.Length != 2)
                    throw new InvalidOperationException("It's just allowed 2 params.");
                Console.WriteLine($"Result of division ({args[0]} / {args[1]}) : {Divide(double.Parse(args[0]), double.Parse(args[1]))}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"InvalidOperationException {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message}");
            }
            finally
            {
                Console.WriteLine("Division function says: See you soon");
            }
        }

        static void InstructionUsing()
        {
            using (System.IO.TextWriter oTextWriter = System.IO.File.CreateText("test.txt"))
            {
                oTextWriter.WriteLine("Line 1");
                oTextWriter.WriteLine("Line 2");
                oTextWriter.WriteLine("Line 3");
            }

            // The using command makes sure that the object oTextWriter will be disposed from the memory...
        }

    }
}
