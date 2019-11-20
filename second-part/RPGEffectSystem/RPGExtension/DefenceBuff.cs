using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class DefenceBuff: Effect, IDefenceEffect
    {
        float damageReductionPercent;
        public DefenceBuff(int duration, float damageReductionPercent) : base(duration)
        {
            this.damageReductionPercent = damageReductionPercent;
        }

        public float modifyHit(float hit)
        {
            return hit / (1 + damageReductionPercent);
        }
    }
}
