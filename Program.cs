using System;
using System.Collections.Generic;
using System.IO;

namespace pa2_agcrofoot_1
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        throw new Exception("Please enter a valid input.");
                    }
                    break;
                }
                catch(Exception e)
                {
                    //Presents error message 
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Random random1 = new Random();
            int power1 = random1.Next(0, 100);
            Character playerOne = Player1(char1Name, power1, powerChoice1);

            IAttack playerOneAttack = Player1Attack(powerChoice1, power1);

            playerOne.SetAttackPower(playerOneAttack);


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
                        throw new Exception("Please enter a valid input.");
                    }
                    break;
                }
                catch(Exception e)
                {
                    //Presents error message 
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            Random random2 = new Random();
            int power2 = random2.Next(0, 100);
            Character playerTwo = Player2(char2Name, power2, powerChoice2);

            IAttack playerTwoAttack = Player2Attack(powerChoice2, power2);

            playerTwo.SetAttackPower(playerTwoAttack);
        }

        public static Character Player1(string char1Name, int power1, int powerChoice1)
        {
            if(powerChoice1 == 1)
            {
                return new Earth(){Name = char1Name, MaxPower = power1, Health = 100};
            }
            else if(powerChoice1 == 2)
            {
                return new Wind(){Name = char1Name, MaxPower = power1, Health = 100};
            }
            else 
            {
                return new Fire(){Name = char1Name, MaxPower = power1, Health = 100};
            }
        }

        public static Character Player2(string char2Name, int power2, int powerChoice2)
        {
            if(powerChoice2 == 1)
            {
                return new Earth(){Name = char2Name, MaxPower = power2, Health = 100};
            }
            else if(powerChoice2 == 2)
            {
                return new Wind(){Name = char2Name, MaxPower = power2, Health = 100};
            }
            else
            {
                return new Fire(){Name = char2Name, MaxPower = power2, Health = 100};
            }
        }

        public static IAttack Player1Attack(int powerChoice1, int power1)
        {
            if(powerChoice1 == 1)
            {
                return new EarthAttack();
            }
            else if(powerChoice1 == 2)
            {
                return new WindAttack();
            }
            else
            {
                return new FireAttack();
            }
        }

        public static IAttack Player2Attack(int powerChoice2, int power2)
        {
            if(powerChoice2 == 1)
            {
                return new EarthAttack();
            }
            else if(powerChoice2 == 2)
            {
                return new WindAttack();
            }
            else
            {
                return new FireAttack();
            }
        }
    }
}
