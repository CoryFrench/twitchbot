using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    internal interface IBotModel : IBindingList
    {
        bool IsConnected { get; }
    }
}
