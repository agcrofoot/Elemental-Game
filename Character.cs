using System;

namespace pa2_agcrofoot_1
{
    public class Character
    {
        //Getters and Setters for the Character class
        public string Name{get; set;}
        public int MaxPower{get; set;}
        public int Health{get; set;}
        public int AttackPower{get; set;}
        public int DefensePower{get; set;}

        //Instantiates the IAttack and IDefense
        public IAttack attackBehavior;
        public IDefense defenseBehavior;

        //Sets attackBehavior based on the assigned value
        public void SetAttackBehavior(IAttack value)
        {
            attackBehavior = value;
        }
        //Sets defenseBehavior based on the assigned value
        public void SetDefenseBehavior(IDefense value)
        {
            defenseBehavior = value;
        }

        //Constructs basic character stats
        public Character()
        {
            Random random = new Random();
            int power = random.Next(0, 100);
            Health = 100;
            AttackPower = random.Next(power) + 1;
            DefensePower = random.Next(power) + 1;

        }

        //Displays character stats
        public void Stats()
        {
            Console.WriteLine($"{Name} with: {Health} Health; {AttackPower} Attack Power; {DefensePower} Defense Power");
        }

        //Defends 
        public void Defense(int power)
        {
            power = defenseBehavior.Defense(power);
            Health -= power;
            Console.WriteLine($"{power} damage was done to {this.Name}");
        }
    }
}