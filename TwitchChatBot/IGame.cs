using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// IGame represents the Context object in our State pattern
    /// </summary>
    interface IGame
    {
        IGameState State { get; set; }

        void Announce(string v);
        void AddPlayer(IPlayer player);
        void End();
    }
}
