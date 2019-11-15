using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGEffectSystem
{
    public class NPC : Fightable
    {
        public NPC(float maxHealth, float minDamage, float maxDamage, string name = "Mob") : 
            base(maxHealth, minDamage, maxDamage, name)
        {

        }

        public void reset()
        {
            setHP(maxHealth);
        }
    }
}
