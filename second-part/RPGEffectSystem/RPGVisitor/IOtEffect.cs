using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    interface IOtEffect: IEffect
    {
        void activate();
    }
}
