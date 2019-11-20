using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class DotEffect : Effect, OverTimeEffect
    {
        float tickDamage;
        ExtensibleFightable target;
        public DotEffect(int duration, float tickDamage, ExtensibleFightable target) : base(duration)
        {
            this.tickDamage = tickDamage;
            this.target = target;
        }

        public void activate()
        {
            target.receiveDamage(tickDamage);
        }
    }
}
