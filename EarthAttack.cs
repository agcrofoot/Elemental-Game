using System;

namespace pa2_agcrofoot_1
{
    public class EarthAttack : IAttack
    {
        public void Attack(Character attacker, Character defender)
        {
            //Announces attack
            Console.WriteLine(attacker.Name + " attacked " + defender.Name + " with Earth!");
            int attackPower;
            if(defender.GetType().ToString() == "pa2-agcrofoot-1.WindCharacter")
            {
                //Increases power if opponent is a Wind character
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