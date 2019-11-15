using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class BuffDecorator : EffectDecorator
    {
        public BuffDecorator(IFightableObject fightable, int duration , string roleName = "buff")
            : base(fightable, duration, roleName)
        { }

        public override void endTurn()
        {
            duration -= 1;
            fighter.endTurn();
        }
    }
}
