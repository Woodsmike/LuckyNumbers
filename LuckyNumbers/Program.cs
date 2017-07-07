using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAnswer;
            string jackpotAmount = "12,000,000.00";
            Console.WriteLine("Welcome to LUCKY NUMBERS! How lucky are YOU?\n");
            Console.WriteLine("Press any key to continue.");
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Console.ReadKey();
            Console.Clear();
            do
            {
                Console.WriteLine("The current Jackpot amount is : $" + jackpotAmount + "\n");
                Console.WriteLine("In order to play this game you must choose \n" +
                    " a range of numbers by picking the lowest number in the range and \n"+
                    " picking the highest number in the range.\n");
                Console.WriteLine("Please enter the lowest number in the range.");
                int lowestNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the highest number in the range.");
                int highestNumber = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Please pick your 6 numbers!\n");
                int i = 0;
                int[] numbersPicked = new int[6];
                int number;
                string numberString;
                
                for (i = 0; i < 6; i++)
                {
                     
                    Console.Write("Number: ", i);
                    numberString = Console.ReadLine();
                    bool intResultTryParse = int.TryParse(numberString, out number);
                    while (number < lowestNumber || number > highestNumber)
                    {
                        Console.Write("Please enter a number within your range: ", i);
                        numberString = Console.ReadLine();
                        intResultTryParse = int.TryParse(numberString, out number);
                        
                    }
                    numbersPicked[i] = number;
                }
                foreach(int numbers in numbersPicked)
                {
                    Console.WriteLine(numbers);
                }

                Console.WriteLine(numbersPicked[5]);


                Console.WriteLine("Do you want to play again?");
                userAnswer = Console.ReadLine().ToLower();

            } while (userAnswer == "yes");
            Console.WriteLine("\"Thanks for playing!\"");
        }
    }
}
