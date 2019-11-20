using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class ExtensibleFightable : Fightable
    {
        protected Dictionary<String, List<IEffect>> effects;
        public ExtensibleFightable(float maxHealth, float minDamage, float maxDamage, string name = "Fighter")
            : base(maxHealth, minDamage, maxDamage, name)
        {
            effects = new Dictionary<string, List<IEffect>>();
            effects.Add("ote", new List<IEffect>());
            effects.Add("att", new List<IEffect>());
            effects.Add("def", new List<IEffect>());
            effects.Add("invincibility", new List<IEffect>());
        }

        public void addEffect(IEffect effect, string type)
        {
            effects[type].Add(effect);
        }

        public void removeEffect(string type, IEffect effect = null)
        {
            if (effect == null)
            {
                effects[type].RemoveAt(0);
            }
            else
            {
                effects[type].Remove(effect);
            }
        }

        public override void endTurn()
        {
            activateOts();
            removeEffects();
            base.endTurn();
        }

        private void removeEffects()
        {
            string[] types = { "att", "def", "ote", "invincibility" };
            foreach (string type in types)
            {
                List<IEffect> toRemove = new List<IEffect>();
                foreach (IEffect effect in effects[type])
                {
                    bool expired = effect.expire();
                    if (expired) toRemove.Add(effect);
                }

                foreach (IEffect effect in toRemove)
                {
                    effects[type].Remove(effect);
                }
            }
            
        }

        private void activateOts()
        {
            foreach (IEffect otEffect in effects["ote"])
            {
                try
                {
                    ((OverTimeEffect)otEffect).activate();
                }
                catch (InvalidCastException err)
                {
                    Console.WriteLine("There is an invalid effect in over time effects");
                    Console.WriteLine(err.Message);
                }
            }
        }

        public override float dealDamage(IFightableObject target, float multiplicator = 1)
        {
            foreach (IEffect attackEffect in effects["att"])
            {
                try
                {
                    multiplicator = ((IAttackEffect)attackEffect).modifyAttack(multiplicator);
                }
                catch (InvalidCastException err)
                {
                    Console.WriteLine("There is an invalid effect in attack effects");
                    Console.WriteLine(err.Message);
                }
            }
            
            return base.dealDamage(target, multiplicator);
        }

        public override float receiveDamage(float baseDamage)
        {
            float multiplicator = 1f;
            if (effects["invincibility"].Count > 0)
            {
                float immune = ((IDefenceEffect)effects["invincibility"][0]).modifyHit(baseDamage);
                if (immune == 0) return 0;
            }

            foreach (IEffect defenceEffect in effects["def"])
            {
                try
                {
                    multiplicator = ((IDefenceEffect)defenceEffect).modifyHit(multiplicator);
                }
                catch (InvalidCastException err)
                {
                    Console.WriteLine("There is an invalid effect in attack effects");
                    Console.WriteLine(err.Message);
                }
            }

            return base.receiveDamage(baseDamage * multiplicator);
        }
    }
}
