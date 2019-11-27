using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class RegularEffectVisitor : IEffectVisitor
    {
        // Following methods handle maintenance of effects: new ones, old ones and expired ones.
        // New effects get applied, old effects have their changes removed.
        // Each method returns if the effect has expired.

        public bool visit(AttackEffect effect)
        {
            if (effect.isNewEffect())
            {
                effect.modifyStats(true);
            }
            bool expired = effect.expire();
            if (expired)
            {
                effect.modifyStats(false);
            }
            return expired;
        }

        // Returns the opposite of the effect value, if an effect is expired. Else returns NaN.
        public bool visit(DefenceEffect effect)
        {
            if (effect.isNewEffect())
            {
                effect.modifyStats(true);
            }
            bool expired = effect.expire();
            if (expired)
            {
                effect.modifyStats(false);
            }
            return expired;
        }

        public bool visit(IOtEffect effect)
        {
            effect.activate();
            return effect.expire();
        }

        public bool visit(Effect effect)
        {
            return effect.expire();
        }
    }
}
