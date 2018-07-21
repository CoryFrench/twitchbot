using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// IGameState represents the State interface in our State pattern.
    /// </summary>
    interface IGameState
    {
        /// <summary>
        /// Register a player for the game, if the current IGameState permits.  We should probably let players know if
        /// they try to register when registrations aren't allowed.
        /// </summary>
        /// <param name="player">Player trying to register</param>
        void Register(IPlayer player);
    }
}
