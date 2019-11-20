using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    interface IAttackEffect : IEffect
    {
        float modifyAttack(float baseMulti);
    }
}
