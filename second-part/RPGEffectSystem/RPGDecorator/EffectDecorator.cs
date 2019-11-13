using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    // To do
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
        public EffectDecorator[] getRole(EffectDecorator parent, string role)
        {
            EffectDecorator nextDecorator = ((EffectDecorator)(parent.fighter));
            if (nextDecorator == null) return null;

            if (nextDecorator.roleName == role)
            {
                EffectDecorator[] result = { nextDecorator, parent };
                return result;
            }
            
            return nextDecorator.getRole(nextDecorator, role);
        }

        public EffectDecorator removeRole(EffectDecorator eff, string role)
        {
            // decorators: [1] - decorator to remove, [2] - decorator that decorated the removed object.
            EffectDecorator[] decorators = getRole(eff, role);
            if (decorators == null) return null;
            // decorators[2].fighter == decorators[1]
            decorators[2].fighter = decorators[1].fighter;
            return decorators[1];
        }

        public float dealDamage(float bonusDamage, IFightableObject target)
        {
            return fighter.dealDamage(bonusDamage, target);
        }

        public float receiveDamage(float baseDamage)
        {
            return fighter.receiveDamage(baseDamage);
        }
    }
}
