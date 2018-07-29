using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Encounter : IEncounter
    {
        public List<ICreature> CreaturesNotDead = new List<ICreature>();
        public List<IPlayer> PlayersNotDead = new List<IPlayer>();

        public Encounter(IGame game)
        {
            for (int x = 0; x < game.GetPlayerCount(); x++)
            {
                PlayersNotDead.Add(game.GetPlayer(x));
                CreaturesNotDead.Add(new Creature("Skeleton", 12, 4, 2, 1, 2, 2));
                if (RNG.GetInt(0, 2) > 0)
                { 
                    CreaturesNotDead.Add(new Creature("Skeleton", 12, 4, 2, 1, 2, 2));
                }
            }
        }

        public void AddCreature(ICreature creature)
        {
            this.CreaturesNotDead.Add(creature);
        }

        public void AddPlayer(IPlayer player)
        {
            this.PlayersNotDead.Add(player);
        }

        public void Resolve()
        {
            while (PlayersNotDead.Count != 0 && CreaturesNotDead.Count != 0)
            {
                var deadCreatures = new List<ICreature>();
                foreach (IPlayer player in PlayersNotDead)
                {
                    // Attack Creatures Code
                    foreach(Player attackingPlayer in PlayersNotDead)
                    {
                        var target = CreaturesNotDead[RNG.GetInt(0, CreaturesNotDead.Count - 1)];
                        attackingPlayer.Attack(target);
                        if (target.CurrentHP <= 0)
                        {
                            deadCreatures.Add(target);
                        }
                    }

                }
                foreach (ICreature deadCreature in deadCreatures)
                {
                    CreaturesNotDead.RemoveAll(creatureToMatch => creatureToMatch == deadCreature);
                }
                foreach (ICreature creature in CreaturesNotDead)
                {
                    // Attack Players Code
                    foreach(Creature attackingCreature in CreaturesNotDead)
                    {
                        var target = PlayersNotDead[RNG.GetInt(0, PlayersNotDead.Count - 1)];
                        attackingCreature.Attack(target);
                        if (target.CurrentHP <= 0)
                        {
                            deadCreatures.Add(target);
                        }
                    }
                }
                foreach (ICreature deadCreature in deadCreatures)
                {
                    PlayersNotDead.RemoveAll(creatureToMatch => creatureToMatch == deadCreature);
                }
            }
        }
    }
}
