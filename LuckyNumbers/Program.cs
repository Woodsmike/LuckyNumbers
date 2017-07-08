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
                
                int[] randomNumberArray = new int[6];
                Console.WriteLine("\nYour lucky numbers are : \n");
                for (int j = 0; j < 6; j++)
                {

                int ranNums = rNumber.Next((lowestNumber), (highestNumber));
                    while(!randomNumberArray.Contains(ranNums))
                    {
                        break; 
                    }
                   
                    randomNumberArray[j] = ranNums;
                }
                
                foreach (int ranNums in randomNumberArray)
                {
                    Console.WriteLine("Lucky Number : " + ranNums);

                }
                int randomNum1 = randomNumberArray[0]; 
                int randomNum2 = randomNumberArray[1]; 
                int randomNum3 = randomNumberArray[2]; 
                int randomNum4 = randomNumberArray[3];
                int randomNum5 = randomNumberArray[4];
                int randomNum6 = randomNumberArray[5];
                int totalNumberOfCorrectPicks = 0;
                for(int l = 1; l <=5; l++)
                {
                    if (randomNum1 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (randomNum2 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (randomNum3 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (randomNum4 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (randomNum5 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (randomNum6 == numbersPicked[l])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                }
                Console.WriteLine("\nYou guessed " + totalNumberOfCorrectPicks + " numbers correctly");
                
                
                Console.WriteLine("Do you want to play again?");
                userAnswer = Console.ReadLine().ToLower();
                Console.Clear();

            } while (userAnswer == "yes");
            Console.WriteLine("\"Thanks for playing!\"");
        }
    }
}
