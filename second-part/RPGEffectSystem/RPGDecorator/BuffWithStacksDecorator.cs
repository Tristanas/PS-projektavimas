using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class BuffWithStacksDecorator: BuffDecorator
    {
        protected int stacks;
        public BuffWithStacksDecorator(IFightableObject fightable, int duration, int stacks, string roleName = "ot")
            : base(fightable, duration, roleName)
        {
            this.stacks = stacks;
        }

        public override void endTurn()
        {
            duration--;
            if (stacks <= 0)
            {
                duration = 0;
            }

            fighter.endTurn();
        }
    }
}
