using RPGEffectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IFightableObject player = new Player(100f, 3f, 5f), mob = new NPC(40f, 2f, 3f);
            // Over time effect role name:
            string oteRoleName = EffectDecorator.overTimeEffectRoleName;

            EffectDecorator playerBuffs = new EffectDecorator(
                new DamageBuffDecorator(
                    new DefenceBuffDecorator(player, 1, 0.2f),
                    3, 1.4f),
                9999),
            mobBuffs = new EffectDecorator(
               new DamageBuffDecorator(mob, 3, 5f),
               9999);

            IFightableObject buffedPlayer = playerBuffs,
                buffedMob = mobBuffs;

            // turn 1:
            buffedPlayer.dealDamage(buffedMob);
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);

            // turn 2:
            Console.WriteLine("Player uses a healing skill on himself");
            EffectDecorator.addEffect(new HotDecorator(null, 3, 10f, oteRoleName), playerBuffs);
            Console.WriteLine("Mob causes the player to bleed");
            EffectDecorator.addEffect(new DotDecorator(null, 3, 15f, oteRoleName), playerBuffs);
            endTurn(buffedMob, buffedPlayer);

            Console.Read();
        }

        private static void endTurn(IFightableObject fightable, IFightableObject fightable2)
        {
            Console.WriteLine("turn over");
            fightable.endTurn();
            fightable2.endTurn();
            Console.WriteLine("\nnext turn");
        }
    }
}
