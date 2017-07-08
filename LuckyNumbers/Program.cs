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
                //A zero would be stored as an element when trying to attempt the stretch
                //tasks.
                //while attempting the stretch task, the computer would store a zero
                //in as an element instead of the duplicate value.  For some reason
                //it does not do that when a list is used instead of an array.
                for (int j = 0; j < 6; j++)
                {
                    do
                    {
                        numberS = rNumber.Next(lowestNumber, highestNumber);
                    } while (listNumbers.Contains(numberS));
                    listNumbers.Add(numberS);

                }

                //Printed out all the elements in the list
                foreach (int numbr in listNumbers)
                {
                    Console.WriteLine("Lucky Number: " + numbr);

                }

                //first I hard coded the jackpot value.  Then I wanted to make it 
                //closer to real world, so I made a random jackpot amount depending 
                //on the range the user entered.
                string jackpotAmount = "$20,000,000.00";
                decimal jackPot = rNumber.Next((lowestNumber * 100000), (highestNumber * 500000));
                jackpotAmount = jackPot.ToString("C2");

                //I display the current jackpot total
                Console.WriteLine("\n\nCurrent Jackpot Total: " + jackpotAmount + "\n\n");
                Console.WriteLine("Please press any key to continue.");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.ReadKey();
                Console.Clear();

                //I wanted to compared every element in the first array to 
                //every element in the second array to see if they are any
                //matching numbers.  I used a for loop with if statements.
                //I did this to find the total amount of picks that are
                //correct.  Then I printed it to the console.
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

               //I needed to figure out the player's winnings.  I could have used
               //a switch case to determine how many correct picks determined
               //the amount of winnings.  Since I had a random total jackpot, I
               //determined the if statement with a percentage to be the best.
               //I divided the total jackpot by the (7  minus the number of picks
               //correct).  The higher the correct picks the lower the denominator
               //which gives a larger winning amount.
                decimal playersWinnings = 0m;
                if (totalNumberOfCorrectPicks == 0)
                {
                    playersWinnings = 0m;
                }
                else
                {
                    playersWinnings = jackPot / (7 - totalNumberOfCorrectPicks);
                }

                //I printed out the player's winnings
                Console.WriteLine("You won " + playersWinnings.ToString("C2") + "!\n");
                Console.WriteLine("Please press any key to continue.");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.ReadKey();
                Console.Clear();

                //If the user answers yes to the following question then it will
                //loop around (because I used the do-while loop) to begin the 
                //game again.
                Console.WriteLine("Do you want to play again?  YES/NO \n");
                userAnswer = Console.ReadLine().ToLower();
                Console.Clear();
                
                while(userAnswer != "no" && userAnswer != "yes")
                {
                    Console.WriteLine("Do you want to play again?  YES/NO \n");
                    userAnswer = Console.ReadLine().ToLower();
                }
                Console.Clear();
            } while (userAnswer == "yes");            
        }
    }
}

