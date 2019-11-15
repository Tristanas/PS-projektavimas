using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    // Healing over time effect decorator.
    class HotDecorator : OverTimeEffectDecorator
    {
        private float tickHeal;
        public HotDecorator(IFightableObject fightable, int duration, float tickHeal, string roleName = "hot")
            : base(fightable, duration, roleName)
        {
            this.tickHeal = tickHeal;
        }

        public override void activate()
        {
            fighter.heal(tickHeal);
        }
    }
}
