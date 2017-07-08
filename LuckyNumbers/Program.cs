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
            Console.WriteLine("If you are feeling lucky, press any key to continue.");
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Console.ReadKey();
            Console.Clear();
            do
            {
                Console.WriteLine("The current Jackpot amount is : $" + jackpotAmount + "\n");
                Console.WriteLine("In order to play this game you must choose a range\n" +
                    "of numbers by picking the lowest number in the range\n"+
                    "and picking the highest number in the range.\n");
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
                        Console.Write("Please enter a number within your range of "
                            + lowestNumber + " - " + highestNumber + ".\nNumber: ", i);
                        numberString = Console.ReadLine();
                        intResultTryParse = int.TryParse(numberString, out number);
                        
                    }
                   
                    numbersPicked[i] = number;
                }
                Console.WriteLine("\n\n");

                Console.Clear();
                Console.Write("You entered : ");
                foreach (int numbs in numbersPicked)
                {                    
                    Console.Write(numbs + " ");
                }
                
                Random rNumber = new Random();
                List<int> listNumbers = new List<int>();
                int numberS;
                int ranNums;
                int[] randomNumberArray = new int[6];
                Console.WriteLine("\nYour lucky numbers are : \n");
                for (int j = 0; j < 6; j++)
                {
                    do
                    {
                        numberS = rNumber.Next(lowestNumber, highestNumber);
                    } while (listNumbers.Contains(numberS));
                    listNumbers.Add(numberS);
                   
                }

                    foreach (int numbr in listNumbers)
                {
                    Console.WriteLine("Lucky Number: " + numbr);

                }
                
                int totalNumberOfCorrectPicks = 0;
                for(int l = 0; l < 6; l++)
                {
                    if (listNumbers[0] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[1] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[2] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[3] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[4] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[5] == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                }
                Console.WriteLine("\nYou guessed " + totalNumberOfCorrectPicks + " numbers correctly\n");

                decimal jackpotAmountDec = decimal.Parse(jackpotAmount);
                decimal playersWinnings = jackpotAmountDec / (7 - totalNumberOfCorrectPicks);

                
                Console.WriteLine("You won " + playersWinnings.ToString("C2") + "!\n");
                Console.WriteLine("Please press any key to continue.");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Do you want to play again?\n");
                Console.WriteLine("Type \"Yes\" or any other key to exit.");
                userAnswer = Console.ReadLine().ToLower();
                Console.Clear();

            } while (userAnswer == "yes");
            Console.WriteLine("\"Thanks for playing!\"\n\n");
        }
    }
}
