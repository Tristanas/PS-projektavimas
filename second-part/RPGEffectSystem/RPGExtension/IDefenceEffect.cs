using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    interface IDefenceEffect : IEffect
    {
        float modifyHit(float hit);
    }
}
