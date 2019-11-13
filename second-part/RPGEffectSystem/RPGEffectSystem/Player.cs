using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGEffectSystem
{
    public class Player : IFightableObject
    {
        private float currentHealth;
        public float maxHealth;
        public float minDamage;
        public float maxDamage;

        public Player(float maxHealth, float minDamage, float maxDamage)
        {
            this.maxHealth = maxHealth;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.currentHealth = maxHealth;
        }

        public float dealDamage(IFightableObject target, float bonusDamage = 0)
        {
            float effectiveDamage = bonusDamage + (minDamage + maxDamage) / 2;
            float damageDealt = target.receiveDamage(effectiveDamage);
            return damageDealt;
        }

        public float receiveDamage(float baseDamage)
        {
            return baseDamage;
        }
    }
}
