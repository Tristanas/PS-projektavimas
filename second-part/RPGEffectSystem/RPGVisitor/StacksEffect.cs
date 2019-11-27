using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    abstract class StacksEffect: Effect
    {
        protected int stacks;
        public StacksEffect(int duration, int stacks) : base(duration)
        {
            this.stacks = stacks;
        }

        public override bool expire()
        {
            if (stacks <= 0)
            {
                duration = 0;
            }
            return base.expire();
        }

        abstract public float modifyHit(float hit);
    }
}
