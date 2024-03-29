﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class HotEffect : Effect, IOtEffect
    {
        IFightableObject target;
        float tickHeal;
        
        public HotEffect(int duration, float tickHeal, IFightableObject target) : base(duration)
        {
            this.tickHeal = tickHeal;
            this.target = target;
        }

        public void activate()
        {
            target.heal(tickHeal);
        }

        public override bool acceptVisitor(IEffectVisitor visitor)
        {
            return visitor.visit(this);
        }

        
    }
}
