using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    // Damage over time effect decorator.
    class DotDecorator: OverTimeEffectDecorator
    {
        private float tickDamage;
        public DotDecorator(IFightableObject fightable, int duration, float tickDamage, string roleName = "dot")
            : base(fightable, duration, roleName)
        {
            this.tickDamage = tickDamage;
        }

        public override void activate()
        {
            fighter.receiveDamage(tickDamage);
        }
    }
}
