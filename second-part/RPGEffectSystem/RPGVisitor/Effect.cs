using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class Effect: IEffect
    {
        protected int duration;
        public int maxDuration;

        public Effect(int duration)
        {
            this.maxDuration = duration;
            this.duration = duration;
        }

        public float acceptVisitor(IEffectVisitor visitor)
        {
            return visitor.visit(this);
        }

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
