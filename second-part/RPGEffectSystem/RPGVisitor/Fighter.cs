using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class Fighter: IFightableObject
    {
        public string name;
        private float currentHealth;
        public float maxHealth;
        // Hit is between minDamage and maxDamage. Currently it's the average. Should be random eventually.
        public float minDamage;
        public float maxDamage;

        // Divides incoming damage by a number.
        public float defenceMultiplicator;

        List<IEffect> effects;
        IEffectVisitor effectVisitor = new RegularEffectVisitor();

        public Fighter(float maxHealth, float minDamage, float maxDamage, string name = "Fighter")
        {
            this.maxHealth = maxHealth;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.currentHealth = maxHealth;
            this.name = name;
            defenceMultiplicator = 1f;

            effects = new List<IEffect>();
        }

        virtual public float dealDamage(IFightableObject target, float multiplicator = 1)
        {
            float effectiveDamage = Math.Max(0, multiplicator * (minDamage + maxDamage) / 2);
            Console.WriteLine($"{name} attacks opponent for {effectiveDamage} potential damage.");
            float damageDealt = target.receiveDamage(effectiveDamage);
            return damageDealt;
        }

        virtual public float receiveDamage(float baseDamage)
        {
            float effectiveDamage = baseDamage / defenceMultiplicator;
            Console.WriteLine($"{name} received {effectiveDamage} damage.");
            this.currentHealth -= effectiveDamage;
            return effectiveDamage;
        }

        protected void setHP(float newHP)
        {
            this.currentHealth = newHP;
        }

        public void heal(float hp)
        {
            float initialHp = currentHealth;
            currentHealth = Math.Min(currentHealth + hp, maxHealth);
            float actualHeal = currentHealth - initialHp;
            Console.WriteLine($"{name} healed {actualHeal}.");

        }

        virtual public void endTurn()
        {
            heal(0.01f * maxHealth);
            List<IEffect> toRemove = new List<IEffect>();
            foreach(IEffect effect in effects)
            {
                if (effect.acceptVisitor(effectVisitor))
                {
                    toRemove.Add(effect);
                }
            }
            toRemove.ForEach((element) => effects.Remove(element));
        }

        public void affectAttack(float multiplicator)
        {
            if (multiplicator <= 0) return;
            this.minDamage *= multiplicator;
            this.maxDamage *= multiplicator;
        }

        public void affectDefence(float multiplicator)
        {
            if (multiplicator <= 0) return;
            defenceMultiplicator *= multiplicator;
        }

        public void addStatusEffect(StatusEffect effect)
        {
            effects.Add(effect);
            effect.modifyTargetStats(true);
        }

        public void addEffect(IEffect effect)
        {
            effects.Add(effect);
        }
    }
}
