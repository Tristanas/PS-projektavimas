using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class HotEffect: Effect, OverTimeEffect
    {
        float tickHeal;
        ExtensibleFightable target;
        public HotEffect(int duration, float tickHeal, ExtensibleFightable target): base(duration)
        {
            this.tickHeal = tickHeal;
            this.target = target;
        }

        public void activate()
        {
            target.heal(tickHeal);
        }
    }
}
