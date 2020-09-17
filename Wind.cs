using System;

namespace pa2_agcrofoot_1
{
    public class Wind : Character
    {
        public Wind() : base()
        {
            SetAttackBehavior(new WindAttack());
            SetDefenseBehavior(new Defend());
        }
    }
}