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
                foreach (IPlayer player in PlayersNotDead)
                {
                    // Check for death
                    if(player.CurrentHP >= 0)
                    {
                        PlayersNotDead.Remove(player);
                    }
                    // Attack Creatures Code
                    foreach(Player attackingPlayer in PlayersNotDead)
                    {
                        attackingPlayer.Attack(CreaturesNotDead[RNG.GetInt(0, CreaturesNotDead.Count)]);
                    }

                }
                foreach (ICreature creature in CreaturesNotDead)
                {
                    //Check for death
                    if(creature.CurrentHP >= 0)
                    {
                        CreaturesNotDead.Remove(creature);
                    }
                    // Attack Players Code
                    foreach(Creature attackingCreature in CreaturesNotDead)
                    {
                        attackingCreature.Attack(PlayersNotDead[RNG.GetInt(0, PlayersNotDead.Count)]);
                    }
                }
            }
        }
    }
}
