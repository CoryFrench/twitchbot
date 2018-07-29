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
    public interface IGame
    {
        /// <summary>
        /// The State the game is currently in
        /// </summary>
        IGameState State { get; set; }

        /// <summary>
        /// Prints string to Twitch channel / Log
        /// </summary>
        /// <param name="v">message to print</param>
        void Announce(string v);
        /// <summary>
        /// Adds a player to the game
        /// </summary>
        /// <param name="player">player to add</param>
        void AddPlayer(IPlayer player);
        /// <summary>
        /// Creates an Encounter
        /// </summary>
        void CreateEncounter();
        /// <summary>
        ///  Ends the game
        /// </summary>
        void End();
    }
}
