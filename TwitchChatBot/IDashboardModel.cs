using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// IDashboardModel is our ViewModel object that we will use data binding with on our BotDashboard
    /// </summary>
    public interface IDashboardModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Returns true if we're connected to Twitch
        /// </summary>
        bool IsConnected { get; set; }
        /// <summary>
        /// Whether or not we should actually try to run the game inside of a Twitch channel or just dump the logs to
        /// our logging window
        /// </summary>
        bool ShouldRunLocalGame { get; set; }
        /// <summary>
        /// Whether or not the ShouldRunLocalGame setting is changeable
        /// </summary>
        bool IsRunLocalGameEnabled { get; set; }

        /// <summary>
        /// All valid game states one could transition to
        /// </summary>
        ICollection<IGameState> AllStates { get; }
    }
}
