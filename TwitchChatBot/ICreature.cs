using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    interface ICreature
    {
        String Name { get; set; }
        String Class { get; set; }
        int CurrentHP { get; set; }
        int MaxHP { get; set; }
        int AC { get; set; }
        void Attack();
    }
}
