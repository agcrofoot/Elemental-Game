using System;

namespace pa2_agcrofoot_1
{
    public class FireAttack : IAttack
    {
        public void Attack(Character attacker, Character defender)
        {
            //Announces attack
            Console.WriteLine(attacker.Name + " attacked " + defender.Name + " with Fire!");
            int attackPower;
            if(defender.GetType().ToString() == "pa2-agcrofoot-1.EarthCharacter")
            {
                //Increases power if opponent is an Earth character
                attackPower = attacker.AttackPower + 5;
            }
            else
            {
                attackPower = attacker.AttackPower;
            }
            //Prompts defense
            defender.Defense(attackPower);
        }
    }
}