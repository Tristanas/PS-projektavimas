using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class Player : ExtensibleFightable
    {
        public Player(float maxHealth, float minDamage, float maxDamage, string name = "Player")
            : base(maxHealth, minDamage, maxDamage, name)
        { }
    }
}
