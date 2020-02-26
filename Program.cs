using System;

namespace NumbersToCurrency
{  

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose your language: ");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Ukrainian");
            string a = Console.ReadLine();

            if (a == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter your value (separate cents by '.'): ");
                string number = Console.ReadLine();
                Console.WriteLine(ConvertToWords.ConvertToWordEng(number));
                Main();
            }
            else if (a == "2")
            {
                Console.Clear();
                Console.WriteLine("Введiть Ваше значення (роздiлiть копiйки символом ','): ");
                string number = Console.ReadLine();
                Console.WriteLine(ConvertToWords.ConvertToWordUkr(number));
                Main();
            }
            else
            {
                Console.Clear();
                Main();
            }

        }
    }
}
