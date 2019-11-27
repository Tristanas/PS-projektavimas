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
        // Old effects have their changes removed.
        // Each method returns if the effect has expired.

        public bool visit(IOtEffect effect)
        {
            effect.activate();
            return effect.expire();
        }

        public bool visit(IEffect effect)
        {
            bool expired = effect.expire();
            if (expired)
            {
                effect.modifyTargetStats(false);
            }
            return expired;
        }
    }
}
