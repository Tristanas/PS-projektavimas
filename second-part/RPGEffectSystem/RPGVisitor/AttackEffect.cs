using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class AttackEffect: Effect
    {
        float damageMultiplicator;
        IFightableObject target;
        public AttackEffect(int duration, IFightableObject target, float damageMultiplicator) : base(duration)
        {
            this.damageMultiplicator = damageMultiplicator;
            this.target = target;
        }

        public void modifyStats(bool newEffect)
        {
            target.affectAttack(newEffect ? 
                damageMultiplicator 
                : 1 / damageMultiplicator);
        }
    }
}
