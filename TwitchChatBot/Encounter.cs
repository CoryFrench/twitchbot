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
                creaturesInCombat.Add(new Creature("Grid Bug", 9, 1, 1, 1, 1, 0, 12, 0, 0));
                creaturesInCombat.Add(new Creature("Grid Bug", 9, 1, 1, 1, 1, 0, 12, 0, 0));
                creaturesInCombat.Add(new Creature("Grid Bug", 9, 1, 1, 1, 1, 0, 12, 0, 0));
                if (RNG.GetInt(0, 2) > 0)
                {
                    creaturesInCombat.Add(new Creature("Grid Bug", 9, 1, 12, 10, 1, 0, 12, 0, 0));
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
                var deadCreatures = new List<ICreature>();
                foreach (ICreature attackingCreature in creaturesInCombat)
                {
                    var target = attackingCreature.GetCreatureFromList(creaturesInCombat);
                    if (target.IsAlive)
                    {

                        if (attackingCreature.IsFriendly(target))
                        {
                            //Do good / heal thing. Placeholder heal action below.
                            if (target.CurrentHP < target.MaxHP)
                            {
                                target.CurrentHP++;
                                Console.WriteLine(attackingCreature.Name + " heals " + target.Name + " for 1 hp");
                            }
                            else
                            {
                                Console.WriteLine("Target already all full hp");
                            }
                        }
                        else
                        {
                            attackingCreature.Attack(target);
                            if (target.CurrentHP <= 0)
                            {
                                if (target.IsPlayer) { playersAlive--; }
                                else if (!target.IsPlayer) { creaturesAlive--; }
                                target.IsAlive = false;
                                deadCreatures.Add(target);
                            }
                        }
                    }
                }
                foreach (ICreature deadCreature in deadCreatures)
                {
                    creaturesInCombat.RemoveAll(creatureToMatch => creatureToMatch == deadCreature);
                }
            }
        }
    }
}
