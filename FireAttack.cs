using System;

namespace pa2_agcrofoot_1
{
    public class FireAttack : IAttack
    {
        public void Attack(Character attacker, Character defender)
        {
            Console.WriteLine(attacker.Name + " attacked " + defender.Name + " with Fire!");
            int attackPower;
            if(defender.GetType().ToString() == "pa2-agcrofoot-1.EarthCharacter")
            {
                attackPower = attacker.AttackPower + 5;
            }
            else
            {
                attackPower = attacker.AttackPower;
            }

            defender.Defense(attackPower);
        }
    }
}