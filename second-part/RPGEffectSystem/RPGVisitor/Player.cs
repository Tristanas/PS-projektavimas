using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class Player: Fighter
    {
        public Player(float maxHealth, float minDamage, float maxDamage, string name = "Player")
            : base(maxHealth, minDamage, maxDamage, name)
        { }
    }
}
