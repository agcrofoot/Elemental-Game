using System;
using System.Collections.Generic;
using System.IO;

namespace pa2_agcrofoot_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Repeats the code
            while(true)
            {
                //Creates Player 1
                Console.Clear();
                Console.WriteLine("Player 1: What is the name of your character?");
                string char1Name = Console.ReadLine();
                Console.WriteLine("Player 1: Does " + char1Name + " draw their power from Earth (1), Wind (2), or Fire (3)?");
                int powerChoice1 = 0;
                while(true)
                {
                    try
                    {
                        //Tries to parse the input and check if it is within the boundaries
                        powerChoice1 = int.Parse(Console.ReadLine());
                        if(powerChoice1 < 1 || powerChoice1 > 3)
                        {
                            Console.Clear();
                            throw new Exception("Please enter a valid input.");
                        }
                        break;
                    }
                    catch(Exception e)
                    {
                        //Presents error message
                        Console.Clear(); 
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Does " + char1Name + " draw their power from Earth (1), Wind (2), or Fire (3)?");
                        continue;
                    }
                }

                Character playerOne = Player(char1Name, powerChoice1);

                //Creates Player 2
                Console.Clear();
                Console.WriteLine("Player 2: What is the name of your character?");
                string char2Name = Console.ReadLine();
                Console.WriteLine("Player 2: Does " + char2Name + " draw their power from Earth (1), Wind (2), or Fire (3)?");
                int powerChoice2 = 0;
                while(true)
                {
                    try
                    {
                        //Tries to parse the input and check if it is within the boundaries
                        powerChoice2 = int.Parse(Console.ReadLine());
                        if(powerChoice2 < 1 || powerChoice2 > 3)
                        {
                            Console.Clear();
                            throw new Exception("Please enter a valid input.");
                        }
                        break;
                    }
                    catch(Exception e)
                    {
                        //Presents error message 
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Does " + char2Name + " draw their power from Earth (1), Wind (2), or Fire (3)?");
                        continue;
                    }
                }
            
                Character playerTwo = Player(char2Name, powerChoice2);

                Console.Clear();

                //Displays the characters and their stats
                Console.WriteLine("The chosen fighters are:");
                playerOne.Stats();
                playerTwo.Stats();

                Console.WriteLine("Press 'Enter' to start the fight!!");
                Console.ReadKey();
                
                //Starts game
                StartGame(playerOne, playerTwo);
                //Announces the winner based on health
                if(playerOne.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(playerOne.Name + " has been defeated! " + playerTwo.Name + " is the winner!!");
                }
                else if(playerTwo.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(playerTwo.Name + " has been defeated! " + playerOne.Name + " is the winner!!");
                }
                //Ends game
                EndOfGame();
            }
        }

        //Creates new character based off of input
        public static Character Player(string charName, int powerChoice)
        {
            if(powerChoice == 1)
            {
                return new Earth(){Name = charName, CharacterType = "Earth"};
            }
            else if(powerChoice == 2)
            {
                return new Wind(){Name = charName, CharacterType = "Wind"};
            }
            else 
            {
                return new Fire(){Name = charName, CharacterType = "Fire"};
            }
        }

        //Creates new character based off of input
        // public static Character Player2(string char2Name, int powerChoice2)
        // {
        //     if(powerChoice2 == 1)
        //     {
        //         return new Earth(){Name = char2Name, CharacterType = "Earth"};
        //     }
        //     else if(powerChoice2 == 2)
        //     {
        //         return new Wind(){Name = char2Name, CharacterType = "Wind"};
        //     }
        //     else
        //     {
        //         return new Fire(){Name = char2Name, CharacterType = "Fire"};
        //     }
        // }

        //Begins game
        public static void StartGame(Character playerOne, Character playerTwo)
        {
            //Randomly chooses between 1 and 2 to determine the player that goes first
            Random num = new Random();
            int choice = num.Next(1, 3);
            if(choice == 1)
            {
                //Sets player 1 to go first
                Console.Clear();
                Console.WriteLine("Player 1 " + playerOne.Name + " goes first!!");
                playerOne.attackBehavior.Attack(playerOne, playerTwo);
                playerTwo.Stats();
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadKey();
                Alternate(playerOne, playerTwo);

            }
            else if (choice == 2)
            {
                //Sets player 2 to go first
                Console.Clear();
                Console.WriteLine("Player 2 " + playerTwo.Name + " goes first!!");
                playerTwo.attackBehavior.Attack(playerTwo, playerOne);
                playerOne.Stats();
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadKey();
                Alternate(playerTwo, playerOne);

            }

        }

        //Alternates plays based on the player that went first
        public static void Alternate(Character first, Character second)
        {
            int oneHealth = first.Health;
            int twoHealth = second.Health;
            int healthPositive = first.Health * second.Health;
            //While the sum of the health of the two characters is not 0, continue the loop
            while(healthPositive > 0)
            {
                Console.Clear();
                second.attackBehavior.Attack(second, first);
                first.Stats();
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadKey();
                healthPositive = first.Health * second.Health;
                if(healthPositive > 0)
                {
                    Console.Clear();
                    first.attackBehavior.Attack(first, second);
                    second.Stats();
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadKey();
                    healthPositive = first.Health * second.Health;
                }
                
                healthPositive = first.Health * second.Health;
            }
        }
        //Allows user to play again or exit
        public static void EndOfGame()
        {
            Console.WriteLine("Good game! Play again?");
            Console.WriteLine("Yes '1'");
            Console.WriteLine("No '2'");
            int endChoice = 0;
            while(true)
            {
                try
                {   
                    endChoice = int.Parse(Console.ReadLine());
                    if(endChoice < 1 || endChoice > 2)
                    {
                        Console.Clear();
                        throw new Exception("Please enter a valid input. Yes '1' or No '2'");
                    }

                    if(endChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Press 'Enter' to return to the menu.");
                        Console.ReadKey();
                        break;
                    }
                    else if(endChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    }
                }
                catch(Exception e)
                {
                    //Presents error message
                    Console.Clear(); 
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Yes '1' or No '2'");
                    continue;
                }
                
            }
        }
    }
}
