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
            //I created a Random object to use throughout the program.  I also initialized
            //the string userAnswer to use in a do while loop
            string userAnswer = " ";
            Random rNumber = new Random();

            //I used the do while loop in order for the user to continue playing
            //if he answered yes to the question "Do you want to play again?"
            do
            {
                Console.WriteLine("Welcome to LUCKY NUMBERS! How lucky are YOU?\n");
                Console.WriteLine("If you are feeling lucky, press any key to continue.");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.ReadKey();
                Console.Clear();
            
                //I had the user enter 2 numbers to determine the range of numbers that
                //they could choose.  I also used these numbers to determine what the
                //random jackpot would be later in the code
                Console.WriteLine("In order to play this game you must choose a range\n" +
                    "of numbers by picking the lowest number in the range\n" +
                    "and picking the highest number in the range.\n");
                Console.WriteLine("Please enter the lowest number in the range.");
                int lowestNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the highest number in the range.");
                int highestNumber = int.Parse(Console.ReadLine());
                Console.Clear();

                //This section is to let the user pick 6 numbers that will automatically
                //be stored into an array called 'numbersPicked'
                Console.WriteLine("Please pick your 6 numbers!\n");
                int i;
                int[] numbersPicked = new int[6];
                int number;
                string numberString;

                //Inside this for loop, I also have a while loop. I used it to make
                //sure the user could only enter numbers, and those numbers would
                //be within the range the user entered.  After all the numbers are picked
                //they are automatically stored into an array.
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

                //After clearing the console I wanted to display the numbers picked
                //to the user, so that they can compare their numbers and the 
                //random numbers generated.
                Console.Write("You entered : ");
                foreach (int numbs in numbersPicked)
                {
                    Console.Write(numbs + " ");
                }

                //For the stretch part of the project I used a list instead of an array.
                //I could not find a way to randomly generate numbers to automatically
                //fill an array....without having duplicates.  After searching for the
                //answer, the best action was to use a list.
                List<int> listNumbers = new List<int>();
                int numberS;

                //I could have used this array to store the random numbers:
                //int[] randomNumberArray = new int[6];
                Console.WriteLine("\nYour lucky numbers are : \n");

                //I used a foor loop with a do while loop nested.  I needed to make 
                //sure the random numbers were inside the range the user entered..and
                //a zero would not be stored as an element.  
                //A zero would be stored as an element when trying to .
                //because while attempting the stretch
                //task, 
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
                string jackpotAmount = "$20,000,000.00";
                decimal jackPot = rNumber.Next((lowestNumber * 100000), (highestNumber * 500000));
                jackpotAmount = jackPot.ToString("C2");


                Console.WriteLine("\n\nCurrent Jackpot Total: " + jackpotAmount + "\n\n");
                Console.WriteLine("Please press any key to continue.");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.ReadKey();
                Console.Clear();

                int totalNumberOfCorrectPicks = 0;
                for (int k = 0; k < 6; k++)
                {
                    if (listNumbers[0] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[1] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[2] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[3] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[4] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                    if (listNumbers[5] == numbersPicked[k])
                    {
                        totalNumberOfCorrectPicks += 1;
                    }
                }
                Console.WriteLine("\nYou guessed " + totalNumberOfCorrectPicks +
                    " numbers correctly\n");

               
                decimal playersWinnings = 0m;
                if (totalNumberOfCorrectPicks == 0)
                {
                    playersWinnings = 0m;
                }
                else
                {
                    playersWinnings = jackPot / (7 - totalNumberOfCorrectPicks);
                }



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
            while (userAnswer == "no")
            {
                Console.WriteLine("\"Thanks for playing!\"\n\n");
                return;
            }
        }
    }
}

