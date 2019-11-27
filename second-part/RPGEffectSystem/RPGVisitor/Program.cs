using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100f, 3f, 5f);
            NPC mob = new NPC(40f, 2f, 3f);

            player.addStatusEffect(new AttackEffect(4, player, 1.4f));
            mob.addStatusEffect(new DefenceEffect(2, mob, 1.2f));

            // turn 1:
            player.dealDamage(mob);
            mob.dealDamage(player);
            endTurn(mob, player);

            // turn 2:
            Console.WriteLine("Player uses a healing skill on himself");
            player.addEffect(new HotEffect(3, 10f, player));
            mob.dealDamage(player);
            endTurn(mob, player);

            // turn 3:
            player.dealDamage(mob);
            mob.dealDamage(player);
            endTurn(mob, player);

            // turn 4:
            player.dealDamage(mob);
            mob.dealDamage(player);
            endTurn(mob, player);

            // turn 5:
            player.dealDamage(mob);
            mob.dealDamage(player);
            endTurn(mob, player);

            Console.WriteLine("\n\n Demonstration over (Press a key to exit)");
            Console.ReadKey();
        }

        private static void endTurn(Fighter fightable, Fighter fightable2)
        {
            Console.WriteLine("Turn over");
            fightable.endTurn();
            fightable2.endTurn();
            Console.WriteLine("\nNext turn (Press a key to continue)");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
