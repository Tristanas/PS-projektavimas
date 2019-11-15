using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class ShieldEffectDecorator: BuffWithStacksDecorator
    {
        private float maxShielding;
        private float shieldedPercentage;

        public ShieldEffectDecorator(IFightableObject fightable, int duration, int stacks, float maxShielding = 10f,
            float shieldedPercentage = 0.5f, string roleName = "ot") : base(fightable, duration, stacks, roleName)
        {
            this.maxShielding = maxShielding;
            this.shieldedPercentage = shieldedPercentage;
        }

        public float shield(float incomingDamage)
        {
            return incomingDamage - Math.Min(maxShielding, incomingDamage * shieldedPercentage);
        }
    }
}
