using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class HotEffect : Effect, IEffect, IOtEffect
    {
        IFightableObject target;
        float tickHeal;
        
        public HotEffect(int duration, float tickHeal, IFightableObject target) : base(duration)
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
