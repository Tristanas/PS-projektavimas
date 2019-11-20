using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGEffectSystem
{
    public class Fightable : IFightableObject
    {
        public string name;
        private float currentHealth;
        public float maxHealth;
        public float minDamage;
        public float maxDamage;

        public Fightable(float maxHealth, float minDamage, float maxDamage, string name = "Fighter")
        {
            this.maxHealth = maxHealth;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.currentHealth = maxHealth;
            this.name = name;
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
            this.currentHealth -= baseDamage;
            return baseDamage;
        }

        protected void setHP(float newHP)
        {
            this.currentHealth = newHP;
        }

        public void heal(float hp)
        {
            Console.WriteLine($"{name} healed {hp}.");
            currentHealth = Math.Min(currentHealth + hp, maxHealth);
        }

        virtual public void endTurn()
        {
            heal(0.01f * maxHealth);
        }
    }
}
