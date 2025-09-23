using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Utils
{
    public class Inputter
    {
        public static string NormalStringer(string inputMsg, bool allowEmpty)
        {
            string result;

            do
            {
                Console.Write($"{inputMsg} ");
                result = Console.ReadLine().Trim();

                if (allowEmpty && string.IsNullOrWhiteSpace(result))
                {
                    return "";
                }

                if (result != null && allowEmpty == false)
                {
                    Console.WriteLine("Input cannot be empty");
                }

                return result;
            }
            while (true);
        }

        public static string RegexStringer(string input, string inputMsg, string outputMsg, bool allowEmpty)
        {
            return input.Trim();
        }

        public static int Inter(string inputMsg, int min, int max, bool allowEmpty)
        {
            string result;

            do
            {
                Console.Write($"{inputMsg}");
                result = Console.ReadLine().Trim();

                if (allowEmpty && string.IsNullOrWhiteSpace(result))
                {
                    return 0;
                }

                if (!allowEmpty && string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Input cannot be empty");
                }

                try
                {
                    int number = int.Parse(result);

                    if (number < min || number > max)
                    {
                        Console.WriteLine($"Input must between: {min} and {max}");
                    }

                    return number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input must be a valid integer.");
                    Console.WriteLine(ex);
                }
            }
            while (true);
        }

        public static decimal Decimaler(string inputMsg, decimal min, decimal max, bool allowEmpty)
        {
            string result;

            do
            {
                Console.Write($"{inputMsg}");
                result = Console.ReadLine().Trim();

                if ( allowEmpty && string.IsNullOrWhiteSpace(result))
                {
                    return 0;
                }

                if (!allowEmpty && string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Input cannot be empty");
                }

                try
                {
                    decimal number = decimal.Parse(result);

                    if ( number < min || number > max)
                    {
                        Console.WriteLine($"Input must between: {min} and {max}");
                    }

                    return number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            while (true);
        }
    }
}
