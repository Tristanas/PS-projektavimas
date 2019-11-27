using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class AttackEffect: StatusEffect
    {
        float damageMultiplicator;
        public AttackEffect(int duration, IFightableObject target, float damageMultiplicator) : base(duration, target)
        {
            this.damageMultiplicator = damageMultiplicator;
        }

        override public void modifyTargetStats(bool newEffect)
        {
            target.affectAttack(newEffect ? 
                damageMultiplicator 
                : 1 / damageMultiplicator);
        }
        public override bool acceptVisitor(IEffectVisitor visitor)
        {
            return visitor.visit(this);
        }
    }
}
