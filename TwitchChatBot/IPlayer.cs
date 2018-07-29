using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    interface IPlayer : ICreature
    {
        String Name { get; set; }
    }
}
