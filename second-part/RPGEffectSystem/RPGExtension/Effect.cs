using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class Effect: IEffect
    {
        protected int duration;

        public Effect(int duration)
        {
            this.duration = duration;
        }

        virtual public bool expire()
        {
            return --duration <= 0;
        }
    }
}
