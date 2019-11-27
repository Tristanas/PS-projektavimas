using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class NPC: Fighter
    {
        public NPC(float maxHealth, float minDamage, float maxDamage, string name = "Mob")
            : base(maxHealth, minDamage, maxDamage, name)
        { }

        public void reset()
        {
            heal(maxHealth);
            // ... panaikinti visus efektus.
        }
    }
}
