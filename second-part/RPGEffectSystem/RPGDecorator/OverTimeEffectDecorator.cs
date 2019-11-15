using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    abstract class OverTimeEffectDecorator: EffectDecorator
    {
        public OverTimeEffectDecorator(IFightableObject fightable, int duration, string roleName = "ot")
            : base(fightable, duration, roleName)
        { }

        abstract public void activate();
    }
}
