using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    /// To do: 
    /// nextTurn()
    /// removeExpiredEffects()
    /// applyDOTs()
    /// applyHOTs()
    class EffectDecorator : IFightableObject
    {
        IFightableObject fighter;
        private string roleName;

        public EffectDecorator(IFightableObject fighter, string roleName)
        {
            this.fighter = fighter;
            this.roleName = roleName;
        }

        // Looks for a decoration of given role starting from given decorator and then through its decorated objects.
        public static EffectDecorator getRole(EffectDecorator startingDecorator, string role)
        {
           if (startingDecorator.roleName == role) return startingDecorator;

            return (EffectDecorator)recursiveSearch(startingDecorator, role).fighter;
        }

        //Return the parent of sought role.
        public static EffectDecorator recursiveSearch(EffectDecorator parent, string role)
        {
            EffectDecorator nextDecorator = ((EffectDecorator)(parent.fighter));
            if (nextDecorator == null) return null;

            if (nextDecorator.roleName == role)
            {
                return parent;
            }

            return recursiveSearch(nextDecorator, role);
        }

        // Removes the first decorator (that is not given decorator) of a given role.
        public static EffectDecorator removeRole(EffectDecorator eff, string role)
        {
            EffectDecorator parent = recursiveSearch(eff, role);
            if (parent == null)
            {
                return null;
            }
            EffectDecorator toRemove = (EffectDecorator)parent.fighter;
            IFightableObject afterDeleted = toRemove.fighter;

            parent.fighter = afterDeleted;
            return toRemove;
        }

        public float dealDamage(IFightableObject target, float bonusDamage)
        {
            return fighter.dealDamage(target, bonusDamage);
        }

        public float receiveDamage(float baseDamage)
        {
            return fighter.receiveDamage(baseDamage);
        }
    }
}
