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
using System.Collections;
using System.ComponentModel;

namespace TwitchChatBot
{
    // TODO: TwitchChatBot probably shouldn't inherit from IGame
    class ChatBot : IGame, IDashboardModel
    {
        TwitchClient _Client = new TwitchClient();
        Action<Action> _UIThreadRunner = null;
        bool _IsConnected = false;
        bool _RunLocalGame = true;
        bool _IsRunLocalGameEnabled = true;
        JoinedChannel _JoinedChannel = null;
        IGameState _GameState = new GameOverState();
        List<IPlayer> _Players = new List<IPlayer>();

        BindingList<LogMessage> _MessageLog = new BindingList<LogMessage>();

        public event EventHandler<LogMessage> MessageLogged;
        public event PropertyChangedEventHandler PropertyChanged;

        public ChatBot()
        {
            _MessageLog.ListChanged += new ListChangedEventHandler(
                (object o, ListChangedEventArgs e) =>
                {
                    if (MessageLogged != null)
                    {
                        MessageLogged(this, _MessageLog[e.NewIndex]);
                    }
                });
        }

        /// <summary>
        /// The State for the Game state machine, calls OnStateEntered when set
        /// </summary>
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

        public bool IsConnected
        {
            get => _IsConnected;
            set
            {
                _IsConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }

        public ICollection<IGameState> AllStates
        {
            get => GameState.AllStates;
        }

        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                _UIThreadRunner(() => PropertyChanged(this, new PropertyChangedEventArgs(property)));
            }
        }

        public bool ShouldRunLocalGame
        {
            get => _RunLocalGame;
            set
            {
                if (_RunLocalGame != value)
                {
                    _RunLocalGame = value;
                    OnPropertyChanged("ShouldRunLocalGame");
                }
            }
        }
        public bool IsRunLocalGameEnabled
        {
            get => _IsRunLocalGameEnabled;
            set
            {
                if (_IsRunLocalGameEnabled != value)
                { 
                    _IsRunLocalGameEnabled = value;
                    OnPropertyChanged("IsRunLocalGameEnabled");
                }
            }
        }

        /// Print a message to the channel
        public void Announce(String message)
        {
            if (ShouldRunLocalGame)
            {
                _MessageLog.Add(new LogMessage(Level.Info, message));
            }
            else if (_JoinedChannel != null)
            {
                _Client.SendMessage(_JoinedChannel, message);
            }
        }

        /// <summary>
        /// Announce the results of the game.  High scores, winner, etc...
        /// </summary>
        public void End()
        {

        }

        public void Whisper(String user, String message)
        {
            _Client.SendWhisper(user, message);
            _MessageLog.Add(new LogMessage(Level.Debug, message));
        }

        public void AddPlayer(IPlayer newPlayer)
        {
            if (!_Players.Any(p => p.Name.Equals(newPlayer.Name, StringComparison.InvariantCultureIgnoreCase)))
            { 
                _Players.Add(newPlayer);
                _MessageLog.Add(new LogMessage(Level.Info, newPlayer.Name + " registered"));
            }
        }

        public void Connect(Action<Action> uiThreadRunner)
        {
            _UIThreadRunner = uiThreadRunner;
            // TODO: Initialize line takes username / oauth token, may want to un-automate this going forward
            _Client.Initialize(new ConnectionCredentials(Properties.Settings.Default.username, Properties.Settings.Default.oauth));
            _Client.OnConnected += new EventHandler<OnConnectedArgs>(OnConnected);
            _Client.Connect();
        }

        public void JoinChannel(string channel)
        {
            _Client.JoinChannel(channel);
            _Client.OnJoinedChannel += new EventHandler<OnJoinedChannelArgs>(OnJoinedChannel);
            _Client.OnMessageReceived += new EventHandler<OnMessageReceivedArgs>(OnMessageReceived);
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var messageAsString = e.ChatMessage.Message.ToString();

            // TODO: Add !about
            // TODO: Add !nextAdventure
            // TODO: Add !playerStats
            switch (messageAsString)
            {
                case "!start":
                    // Setting the State to GameStarted kicks the Game's state machine off
                    State = new GameStartedState();
                    break;
                case "!register":
                    // Depending on GameState, Register may succeed or tell player why registration is closed
                    State.Register(new Player(e.ChatMessage.Username), this);
                    break;
                default:
                    if (!String.IsNullOrEmpty(messageAsString) && messageAsString[0] == '!')
                    {
                        Whisper(e.ChatMessage.Username, "Command not recognized : `" + messageAsString + "`");
                    }
                    break;

            }
        }

        /// <summary>
        /// Event handler for when a Twitch Channel has been joined successfully
        /// </summary>
        /// <param name="sender">The TwitchClient object</param>
        /// <param name="e">args</param>
        private void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _JoinedChannel = new JoinedChannel(e.Channel);
            _MessageLog.Add(new LogMessage(Level.Info, "Joined channel " + _JoinedChannel.Channel));
        }

        /// <summary>
        /// Connection event handler for OAuth completion
        /// </summary>
        /// <param name="sender">TwitchClient object</param>
        /// <param name="e">args</param>
        private void OnConnected(object sender, OnConnectedArgs e)
        {
             IsConnected = true;
        }

        public void CreateEncounter()
        {

        }

    }
}
