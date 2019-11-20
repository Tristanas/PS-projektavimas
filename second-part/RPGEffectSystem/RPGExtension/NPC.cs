using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class NPC : ExtensibleFightable
    {
        public NPC(float maxHealth, float minDamage, float maxDamage, string name = "Mob")
            : base(maxHealth, minDamage, maxDamage, name)
        { }

        public void reset()
        {
            effects["ote"].Clear();
            effects["att"].Clear();
            effects["def"].Clear();
            effects["invincibility"].Clear();
            effects["invincibility"].Add(new InvulnerabilityEffect(1, 9999, float.MaxValue));
        }
    }
}
