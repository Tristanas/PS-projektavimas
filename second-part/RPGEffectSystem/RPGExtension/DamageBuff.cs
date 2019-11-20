using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class DamageBuff: Effect, IAttackEffect
    {
        float damageMultiplicator;
        public DamageBuff(int duration, float damageMultiplicator) : base(duration)
        {
            this.damageMultiplicator = damageMultiplicator;
        }

        public float modifyAttack(float baseMultiplicator)
        {
            return baseMultiplicator * damageMultiplicator;
        }
    }
}
