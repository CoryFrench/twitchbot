using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    interface IEncounter
    {
        void Add(ICreature creature);
        void Resolve();
    }
}
