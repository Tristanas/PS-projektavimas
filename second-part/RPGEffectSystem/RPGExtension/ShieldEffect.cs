using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class ShieldEffect : StackedEffect, IDefenceEffect
    {
        float shieldRatio;
        float shieldLimit;
        public ShieldEffect(int duration, int stacks, float shieldLimit, float shieldRatio) : base(duration, stacks)
        {
            this.shieldLimit = shieldLimit;
            this.shieldRatio = shieldRatio;
        }

        public override float modifyHit(float hit)
        {
            float damageReduction = Math.Max(shieldLimit, hit * shieldRatio);
            float result = stacks > 0 ? hit - damageReduction : hit;
            stacks--;
            return Math.Max(0, result);
        }
    }
}
