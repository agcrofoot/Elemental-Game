using System;

namespace pa2_agcrofoot_1
{
    public class Character
    {
        public string Name{get; set;}
        public int MaxPower{get; set;}
        public int Health{get; set;}
        public int AttackPower{get; set;}
        public int DefensePower{get; set;}

        public IAttack attackBehavior;
        public IDefense defenseBehavior;

        public void SetAttackBehavior(IAttack value)
        {
            attackBehavior = value;
        }
        public void SetDefenseBehavior(IDefense value)
        {
            defenseBehavior = value;
        }

        public Character()
        {
            Random random = new Random();
            int power = random.Next(0, 100);
            Health = 100;
            AttackPower = random.Next(power) + 1;
            DefensePower = random.Next(power) + 1;

        }

        public void Stats()
        {
            Console.WriteLine($"{Name} with: {Health} Health; {AttackPower} Attack Power; {DefensePower} Defense Power");
        }

        public void Defense(int power)
        {
            power = defenseBehavior.Defense(power);
            Health -= power;
            Console.WriteLine($"{power} damage was done to {this.Name}");
        }
    }
}