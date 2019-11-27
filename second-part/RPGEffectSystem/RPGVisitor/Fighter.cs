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
        List<IEffect> effects;
        public string name;
        private float currentHealth;
        public float maxHealth;
        public float minDamage;
        public float maxDamage;
        public float defenceMultiplicator;

        public Fighter(float maxHealth, float minDamage, float maxDamage, string name = "Fighter")
        {
            this.maxHealth = maxHealth;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.currentHealth = maxHealth;
            this.name = name;
            defenceMultiplicator = 1f;
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
            Console.WriteLine($"{name} received {baseDamage} damage.");
            this.currentHealth -= baseDamage * defenceMultiplicator;
            return baseDamage;
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
            this.defenceMultiplicator *= defenceMultiplicator;
        }
    }
}
