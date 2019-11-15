using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class DefenceBuffDecorator : BuffDecorator
    {
        private float reductionFraction;
        public DefenceBuffDecorator(IFightableObject fightable, int duration, float reductionFraction)
            : base(fightable, duration)
        {
            this.reductionFraction = reductionFraction;
        }

        override public float receiveDamage(float baseDamage)
        {
            return fighter.receiveDamage(baseDamage * Math.Max(0, 1 - reductionFraction));
        }
    }
}
