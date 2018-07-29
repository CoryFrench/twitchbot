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
   public interface IGameState
    {
        /// <summary>
        /// Register a player for the game, if the current IGameState permits.  We should probably let players know if
        /// they try to register when registrations aren't allowed.
        /// </summary>
        /// <param name="player">Player trying to register</param>
        /// <param name="game">Active game</param>
        void Register(IPlayer player, IGame game);

        /// <summary>
        /// Just gives our State objects an opportunity to do things upon being entered
        /// </summary>
        /// <param name="game">Active game</param>
        void OnStateEntered(IGame game);

        /// <summary>
        /// Human friendly string name for the state
        /// </summary>
        String Name { get; }
    }
}
