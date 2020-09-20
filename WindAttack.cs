using System;

namespace pa2_agcrofoot_1
{
    public class WindAttack : IAttack
    {
        public void Attack(Character attacker, Character defender)
        {
            //Announces attack
            Console.WriteLine(attacker.Name + " attacked " + defender.Name + " with Wind!");
            int attackPower;
            if(defender.GetType().ToString() == "pa2-agcrofoot-1.FireCharacter")
            {
                //Increases power if opponent is a Fire character
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