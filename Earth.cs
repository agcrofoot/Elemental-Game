using System;

namespace pa2_agcrofoot_1
{
    public class Earth : Character
    {
        public Earth() : base()
        {
            SetAttackBehavior(new EarthAttack());
            SetDefenseBehavior(new Defend());
        }
    }
}