using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100f, 3f, 5f);
            NPC mob = new NPC(40f, 2f, 3f);

            player.addEffect(new DamageBuff(3, 1.4f), "att");
            player.addEffect(new DefenceBuff(1, 0.2f), "def");

            mob.addEffect(new DamageBuff(5, 5f), "att");

            ExtensibleFightable buffedPlayer = player,
                buffedMob = mob;

            // turn 1:
            buffedPlayer.dealDamage(buffedMob);
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);

            // turn 2:
            Console.WriteLine("Player uses a healing skill on himself");
            buffedPlayer.addEffect(new HotEffect(3, 10f, buffedPlayer), "ote");
            Console.WriteLine("Mob causes the player to bleed");
            buffedPlayer.addEffect(new DotEffect(3, 15f, buffedPlayer), "ote");
            endTurn(buffedMob, buffedPlayer);

            // turn 3:
            Console.WriteLine("Player becomes invulnerable for 1 turn");
            buffedPlayer.addEffect(new InvulnerabilityEffect(1, 5, 10f), "invincibility");
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);

            // turn 4:
            buffedPlayer.dealDamage(buffedMob);
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);

            // turn 5:
            buffedPlayer.dealDamage(buffedMob);
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);
            
            // turn 6:
            buffedPlayer.dealDamage(buffedMob);
            buffedMob.dealDamage(buffedPlayer);
            endTurn(buffedMob, buffedPlayer);

            Console.Read();
        }

        private static void endTurn(ExtensibleFightable fightable, ExtensibleFightable fightable2)
        {
            Console.WriteLine("turn over");
            fightable.endTurn();
            fightable2.endTurn();
            Console.WriteLine("\nnext turn");
        }
    }
}
