using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class DamageBuffDecorator : BuffDecorator
    {
        private float boostPercentage;
        public DamageBuffDecorator(IFightableObject fightable, int duration, float boostPercentage)
            : base(fightable, duration)
        {
            this.boostPercentage = boostPercentage;
        }

        override public float dealDamage(IFightableObject target, float multiplicator)
        {
            return fighter.dealDamage(target, multiplicator * boostPercentage);
        }
    }
}
