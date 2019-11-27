using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    interface IEffectVisitor
    {
        bool visit(IOtEffect effect);
        bool visit(IEffect effect);
    }
}
