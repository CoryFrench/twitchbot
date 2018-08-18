using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Encounter : IEncounter
    {
        public List<ICreature> creaturesInCombat = new List<ICreature>();
        public Encounter(IGame game)
        {
            for (int x = 0; x < game.GetPlayerCount(); x++)
            {
                creaturesInCombat.Add(game.GetPlayer(x));
                creaturesInCombat.Add(new Creature("Skeleton", 14, 1, 2, 1, 4, 0, 12, 0, 0));
                creaturesInCombat.Add(new Creature("Skeleton", 14, 1, 2, 1, 4, 0, 12, 0, 0));
                if (RNG.GetInt(0, 2) > 0)
                {
                    creaturesInCombat.Add(new Creature("Skeleton", 14, 1, 2, 1, 4, 0, 12, 0, 0));
                }
            }
        }

        public void AddCreature(ICreature creature)
        {
            this.creaturesInCombat.Add(creature);
        }

        public void AddPlayer(IPlayer player)
        {
            this.creaturesInCombat.Add(player);
        }

        public void Resolve()
        {
            int turn = 1;
            int playersAlive = 0;
            int creaturesAlive = 0;
            creaturesInCombat = creaturesInCombat.OrderByDescending(creature => creature.Speed).ToList();
            foreach (ICreature creature in creaturesInCombat)
            {
                if (creature.IsPlayer) { playersAlive++; }
                else if (!creature.IsPlayer) { creaturesAlive++; }
            }
            while (creaturesAlive != 0 && playersAlive != 0)
            {
                Console.WriteLine("\nIt is turn number {0}", turn);
                var deadCreatures = new List<ICreature>();
                foreach (ICreature attackingCreature in creaturesInCombat)
                {
                    var target = attackingCreature.GetCreatureFromList(creaturesInCombat);
                    //Garbage code to always make creatures find a valid enemy. Feels bad to use, don't like it. But it works for now.
                    while (target.IsPlayer == attackingCreature.IsPlayer)
                    {
                        target = attackingCreature.GetCreatureFromList(creaturesInCombat);
                    }
                    if (target.IsAlive() && attackingCreature.IsAlive())
                    {

                        if (attackingCreature.IsFriendly(target))
                        {
                            //Do good / heal thing
                        }
                        else
                        {
                            attackingCreature.Attack(target);
                            if (target.CurrentHP <= 0)
                            {
                                if (target.IsPlayer) { playersAlive--; }
                                else if (!target.IsPlayer) { creaturesAlive--; }
                                deadCreatures.Add(target);
                            }
                        }
                    }
                }
                foreach (ICreature deadCreature in deadCreatures)
                {
                    creaturesInCombat.RemoveAll(creatureToMatch => creatureToMatch == deadCreature);
                }
                turn++;
            }

            // End Encounter Code

            if(playersAlive == 0)
            {
                // Game Over
                Console.WriteLine("Game over!");
                Console.WriteLine("You made it to level {0}", 1);
            }else
            {
                // Level Up
                foreach(Player player in creaturesInCombat)
                {
                    player.Level++;
                }
                // New Encounter

            }

        }
    }
}
