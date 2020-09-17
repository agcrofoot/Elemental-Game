using System;

namespace pa2_agcrofoot_1
{
    public class Fire : Character
    {
        public Fire() : base()
        {
            SetAttackBehavior(new FireAttack());
            SetDefenseBehavior(new Defend());
        }
    }
}