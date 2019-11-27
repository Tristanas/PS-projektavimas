using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class DefenceEffect: StatusEffect
    {
        float damageReductionPercent;

        public DefenceEffect(int duration, IFightableObject target, float damageReductionPercent) : base(duration, target)
        {
            this.damageReductionPercent = damageReductionPercent;
        }

        public override bool acceptVisitor(IEffectVisitor visitor)
        {
            return visitor.visit(this);
        }

        override public void modifyTargetStats(bool newEffect)
        {
            target.affectDefence(newEffect ?
                damageReductionPercent
                : 1 / damageReductionPercent);
        }
    }
}
