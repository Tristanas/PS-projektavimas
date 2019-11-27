using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    interface IFightableObject
    {
        // Calculates the effective damage the object can deal to other objects.
        float dealDamage(IFightableObject target, float multiplicator = 1);

        // Calculates how much damage an object would receive if it was attacked with given baseDamage.
        float receiveDamage(float baseDamage);

        void endTurn();

        // Heals the target for specified amount of hp. Can't heal over the max hp.
        void heal(float hp);

        void affectAttack(float multiplicator);

        void affectDefence(float multiplicator);

        void addEffect(IEffect effect);
    }
}
