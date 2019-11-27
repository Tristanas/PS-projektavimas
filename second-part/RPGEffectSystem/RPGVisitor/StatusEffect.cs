using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    abstract class StatusEffect: Effect
    {
        protected IFightableObject target;
        public StatusEffect(int duration, IFightableObject target) : base(duration)
        {
            this.target = target;
        }

        abstract public void modifyTargetStats(bool newEffect);
    }
}
