using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Interface representing a player in the game
    /// </summary>
    public interface IPlayer : ICreature
    {
        /// <summary>
        /// Player name
        /// </summary>
        String Name { get; set; }
    }
}
