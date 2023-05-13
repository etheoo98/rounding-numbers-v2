using System.Globalization;

namespace RoundingNumbers
{
    internal class RoundingNumbers
    {
        private static void Main()
        {
            decimal decimalValue;
            int decimalLength;
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            // Read the decimal value from user input
            do
            {
                Console.Write("Enter a number containing a decimal: ");
                var input = Console.ReadLine();

                // If input is a valid decimal number, store it and exit loop
                if (decimal.TryParse(input!.Replace(",", "."), out decimalValue))
                {
                    break;
                }

                Console.WriteLine("Error: The input must be a number containing at least one decimal. Please try again.");

            } while (true);

            // Read the number of decimal places to round to from user input
            while (true)
            {
                Console.Write("Enter the number of decimal places to round off to (1-15): ");
                var input = Console.ReadLine();

                // If input is a valid integer between 1 and 15, store it and exit loop
                if (int.TryParse(input, out decimalLength) && decimalLength is >= 1 and <= 15)
                {
                    break;
                }

                Console.WriteLine("Error: The input must be a whole number between 1 and 15. Please try again.");
            }

            // Round the decimal value to the specified number of decimal places
            string roundedString = Math.Round(decimalValue, decimalLength, MidpointRounding.AwayFromZero).ToString($"F{decimalLength}");
            
            // Replace the first occurrence of the period character with the decimal separator for the current culture
            string output = roundedString.Replace(".", decimalSeparator);
            
            // Print the rounded value to the console
            Console.WriteLine($"Rounded value: {output}");
        }
    }
}