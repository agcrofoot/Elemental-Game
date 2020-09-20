using System;
using System.Collections.Generic;
using System.IO;

namespace pa2_agcrofoot_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
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

                Character playerOne = Player1(char1Name, powerChoice1);

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
            
                Character playerTwo = Player2(char2Name, powerChoice2);

                Console.Clear();

                Console.WriteLine("The chosen fighters are:");
                playerOne.Stats();
                playerTwo.Stats();

                Console.WriteLine("Press 'Enter' to start the fight!!");
                Console.ReadKey();

                StartGame(playerOne, playerTwo);
                EndOfGame();
            }
        }

        public static Character Player1(string char1Name, int powerChoice1)
        {
            if(powerChoice1 == 1)
            {
                return new Earth(){Name = char1Name};
            }
            else if(powerChoice1 == 2)
            {
                return new Wind(){Name = char1Name};
            }
            else 
            {
                return new Fire(){Name = char1Name};
            }
        }

        public static Character Player2(string char2Name, int powerChoice2)
        {
            if(powerChoice2 == 1)
            {
                return new Earth(){Name = char2Name};
            }
            else if(powerChoice2 == 2)
            {
                return new Wind(){Name = char2Name};
            }
            else
            {
                return new Fire(){Name = char2Name};
            }
        }

        public static void StartGame(Character playerOne, Character playerTwo)
        {
            Random num = new Random();
            int choice = num.Next(1, 3);
            if(choice == 1)
            {
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
                Console.Clear();
                Console.WriteLine("Player 2 " + playerTwo.Name + " goes first!!");
                playerTwo.attackBehavior.Attack(playerTwo, playerOne);
                playerOne.Stats();
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadKey();
                Alternate(playerTwo, playerOne);

            }

        }

        public static void Alternate(Character first, Character second)
        {
            int oneHealth = first.Health;
            int twoHealth = second.Health;
            int healthPositive = first.Health * second.Health;
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
                else if(healthPositive <= 0)
                {
                    if(first.Health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(first.Name + " has been defeated! " + second.Name + " is the winner!!");
                    }
                    else if(second.Health <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(second.Name + " has been defeated! " + first.Name + " is the winner!!");
                    }
                }  
                healthPositive = first.Health * second.Health;
            }
        }

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
