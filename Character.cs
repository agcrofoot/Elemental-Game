using System;

namespace pa2_agcrofoot_1
{
    public class Character
    {
        public string Name{get; set;}
        public int MaxPower{get; set;}
        public int Health{get; set;}

        public IAttack attackPower;
        public IDefense defensePower;

        public void SetAttackPower(IAttack value)
        {
            attackPower = value;
        }
        public void SetDefensePower(IDefense value)
        {
            defensePower = value;
        }

        public Character()
        {

        }
    }
}