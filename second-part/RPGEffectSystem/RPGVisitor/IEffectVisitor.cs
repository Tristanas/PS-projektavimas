using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    interface IEffectVisitor
    {
        bool visit(AttackEffect effect);
        bool visit(DefenceEffect effect);
        bool visit(IOtEffect effect);
        bool visit(Effect effect);
    }
}
