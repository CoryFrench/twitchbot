using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib;
using TwitchLib.Api;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Api.Enums;
using TwitchLib.Api.Models;
using TwitchLib.Client.Models;
using TwitchLib.Api.Exceptions;
using TwitchLib.PubSub.Events;
using TwitchLib.Client.Events.Services.MessageThrottler;
using TwitchLib.Api.Services.Events.FollowerService;
using TwitchLib.Client.Exceptions;
using System.Windows.Forms;
using System.Drawing;

namespace TwitchChatBot
{
    class TwitchChatBot : IGame
    {
        TwitchClient _Client = new TwitchClient();
        JoinedChannel _JoinedChannel = null;
        BotDashboard _Dashboard = null;
        IGameState _GameState = null;
        List<IPlayer> _Players = new List<IPlayer>();

        public IGameState State
        {
            get
            {
                return _GameState;
            }
            set
            {
                _GameState = value;
                _GameState.OnStateEntered(this);
            }
        }

        public void Announce(String message)
        {
            if (_JoinedChannel != null)
            {
                _Client.SendMessage(_JoinedChannel, message);
            }
        }
        public void AddPlayer(IPlayer player)
        {
            _Players.Add(player);
        }

        // TODO: We really ought to do proper DataBinding instead of passing the Form in like this.  There's all sorts
        // of code smells with the encapsulation boundaries being violated between these two classes, but I wanted it to get it compiling again quick.
        public void Connect(BotDashboard dash)
        {
            _Dashboard = dash;
            // TODO: Initialize line takes username / oauth token, may want to un-automate this going forward
            _Client.Initialize(new ConnectionCredentials(Properties.Settings.Default.username, Properties.Settings.Default.oauth));
            _Client.OnConnected += new EventHandler<OnConnectedArgs>(OnConnected);
            _Client.Connect();
        }

        public void JoinChannel(string channel)
        {
            if (_Dashboard != null)
            {
                _Dashboard.BeginInvoke((MethodInvoker)delegate ()
                {
                    _Client.JoinChannel(channel);
                    _Client.OnJoinedChannel += new EventHandler<OnJoinedChannelArgs>(OnJoinedChannel);
                });
            }
        }

        // TODO: Should these event handlers be public?

        /// <summary>
        /// Event handler for when a Twitch Channel has been joined successfully
        /// </summary>
        /// <param name="sender">The TwitchClient object</param>
        /// <param name="e">args</param>
        public void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _JoinedChannel = new JoinedChannel(e.Channel);
            //Fluff
            _Client.SendMessage(_JoinedChannel, "Bot joined");
        }

        /// <summary>
        /// Connection event handler for OAuth completion
        /// </summary>
        /// <param name="sender">TwitchClient object</param>
        /// <param name="e">args</param>
        public void OnConnected(object sender, OnConnectedArgs e)
        {
            if (_Dashboard != null)
            { 
                _Dashboard.BeginInvoke((MethodInvoker)delegate ()
                {
                    _Dashboard.SetConnectionColor(Color.Green);
                });
            }
        }
    }
}
