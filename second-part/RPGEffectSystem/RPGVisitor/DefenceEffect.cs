using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class DefenceEffect: Effect
    {
        float damageReductionPercent;
        IFightableObject target;

        public DefenceEffect(int duration, IFightableObject target, float damageReductionPercent) : base(duration)
        {
            this.damageReductionPercent = damageReductionPercent;
            this.target = target;
        }

        override public void modifyTargetStats(bool newEffect)
        {
            target.affectDefence(newEffect ?
                damageReductionPercent
                : 1 / damageReductionPercent);
        }
    }
}
