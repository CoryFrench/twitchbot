using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Encounter : IEncounter
    {

        private List<ICreature> CreaturesNotDead = new List<ICreature>();
        private List<IPlayer> PlayersNotDead = new List<IPlayer>();

        public void Add(ICreature creature)
        {
            this.CreaturesNotDead.Add(creature);
        }

        public void Resolve()
        {
            while (PlayersNotDead.Count != 0 && CreaturesNotDead.Count != 0)
            {
                foreach (IPlayer player in PlayersNotDead)
                {
                    // Attack Creatures Code
                }
                foreach (ICreature creature in CreaturesNotDead)
                {
                    // Attack Players Code
                }
            }
        }
    }
}
