using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    abstract class Effect: IEffect
    {
        protected int duration;
        public int maxDuration;

        public Effect(int duration)
        {
            this.maxDuration = duration;
            this.duration = duration;
        }

        abstract public bool acceptVisitor(IEffectVisitor visitor);

        virtual public bool expire()
        {
            return --duration <= 0;
        }

        public bool isNewEffect()
        {
            return maxDuration == duration;
        }
    }
}
