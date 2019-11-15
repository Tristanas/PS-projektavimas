using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    /// To do: 
    /// applyDOTs()
    /// applyHOTs()
    class EffectDecorator : IFightableObject
    {
        protected IFightableObject fighter;
        private string roleName;
        protected int duration;
        public static string overTimeEffectRoleName = "time-effect";

        public EffectDecorator(IFightableObject fighter, int duration, string roleName = "main")
        {
            this.fighter = fighter;
            this.roleName = roleName;
            this.duration = duration;
        }

        // If I were to make a sophisticated buff system, I would create an buff expiration event whenever duration reaches 0.
        virtual public void endTurn()
        {
            fighter.endTurn();

            // alternatively could first apply healing, then damage effects.
            applyOverTimeEffects(this);
            removeExpiredEffects(this);

        }

        private void applyOverTimeEffects(EffectDecorator startingEffect)
        {
            EffectDecorator currentEffect = startingEffect;
            OverTimeEffectDecorator overTimeEffect;
            while (currentEffect != null)
            {
                overTimeEffect = (OverTimeEffectDecorator)getRole(currentEffect, overTimeEffectRoleName);
                if (overTimeEffect == null)
                {
                    break;
                }
                overTimeEffect.activate();

                if (overTimeEffect.fighter.GetType() != typeof(EffectDecorator))
                    break;
                currentEffect = (EffectDecorator)overTimeEffect.fighter;
            }
        }

        // Removed EffectDecorators lose their last reference and should be collected by the garbage collector.
        static void removeExpiredEffects(EffectDecorator start)
        {
            EffectDecorator currentDecorator = start, decorated;
            while (!currentDecorator.fighter.GetType().IsSubclassOf(typeof(Fightable)))
            {
                decorated = (EffectDecorator)currentDecorator.fighter;
                if (decorated.duration > 0)
                {
                    currentDecorator = decorated;
                }
                else 
                { 
                    currentDecorator.fighter = decorated.fighter;
                }
            }
        }

        // Adds a new effect to the entity. The new effect decorator will be decorated by the second argument.
        public static void addEffect(EffectDecorator toAdd, EffectDecorator decoratesAdded)
        {
            toAdd.fighter = decoratesAdded.fighter;
            decoratesAdded.fighter = toAdd;
        }

        // Looks for a decoration of given role starting from given decorator and then through its decorated objects.
        public static EffectDecorator getRole(EffectDecorator startingDecorator, string role)
        {
           if (startingDecorator.roleName == role) return startingDecorator;
            EffectDecorator parent = recursiveSearch(startingDecorator, role);
            return parent == null ? null : (EffectDecorator)parent.fighter;
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

        //Return the parent of sought role. If decorator of such role was not found, returns null.
        private static EffectDecorator recursiveSearch(EffectDecorator parent, string role)
        {
            if (parent.fighter == null || parent.fighter.GetType() != typeof(EffectDecorator)) return null;
            EffectDecorator nextDecorator = ((EffectDecorator)(parent.fighter));

            if (nextDecorator.roleName == role)
            {
                return parent;
            }

            return recursiveSearch(nextDecorator, role);
        }

        // Effectively, resulting damage will be an arithmetic equation, consisting of addition and multiplication.
        virtual public float dealDamage(IFightableObject target, float multiplicator = 1)
        {
            return fighter.dealDamage(target, multiplicator);
        }

        virtual public float receiveDamage(float baseDamage)
        {
            return fighter.receiveDamage(baseDamage);
        }

        public void heal(float hp)
        {
            fighter.heal(hp);
        }
    }
}
