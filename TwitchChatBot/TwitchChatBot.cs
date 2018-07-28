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
    class TwitchChatBot : IGame, IBotModel
    {
        TwitchClient _Client = new TwitchClient();
        bool _IsConnected = false;
        JoinedChannel _JoinedChannel = null;
        BotDashboard _Dashboard = null;
        IGameState _GameState = new GameOverState();
        List<IPlayer> _Players = new List<IPlayer>();

        BindingList<LogMessage> _MessageLog = new BindingList<LogMessage>();

        public event ListChangedEventHandler ListChanged;

        public TwitchChatBot()
        {
            _MessageLog.ListChanged += new ListChangedEventHandler(
                (object o, ListChangedEventArgs e) =>
                {
                    if (ListChanged != null)
                    {
                        ListChanged(o, e);
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
            get { return _IsConnected; }
            set
            {
                _IsConnected = value;
                if (_Dashboard != null)
                    _Dashboard.OnIsConnectedChanged(IsConnected);
            }
        }

        /// Print a message to the channel
        public void Announce(String message)
        {
            if (_JoinedChannel != null)
            {
                _Client.SendMessage(_JoinedChannel, message);
            }
        }

        /// <summary>
        /// Announce the results of the game.  High scores, winner, etc...
        /// </summary>
        public void End()
        {
            if (_Players.Count == 0)
            {
                Announce("No players registered");
            }
            else
            {
                Announce(_Players[RNG.GetInt(0, _Players.Count - 1)].Name + " wins!");
            }
        }

        public void Whisper(String user, String message)
        {
            _Client.SendWhisper(user, message);
        }

        public void AddPlayer(IPlayer newPlayer)
        {
            if (!_Players.Any(p => p.Name.Equals(newPlayer.Name, StringComparison.InvariantCultureIgnoreCase)))
            { 
                _Players.Add(newPlayer);
                _MessageLog.Add(new LogMessage(Level.Info, newPlayer.Name + " registered"));
            }
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
                    _Client.OnMessageReceived += new EventHandler<OnMessageReceivedArgs>(OnMessageReceived);
                });
            }
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
                        Whisper(e.ChatMessage.Username, "Command not recognized");
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
            if (_Dashboard != null)
            { 
                _Dashboard.BeginInvoke((MethodInvoker)delegate ()
                {
                    IsConnected = true;
                });
            }
        }

        #region IBindingList nonsense... WIP
        public bool AllowNew => false;

        public bool AllowEdit => false;

        public bool AllowRemove => true;

        public bool SupportsChangeNotification => true;

        public bool SupportsSearching => true;

        public bool SupportsSorting => true;

        public bool IsSorted => false;

        public PropertyDescriptor SortProperty => throw new NotImplementedException();

        public ListSortDirection SortDirection => throw new NotImplementedException();

        public bool IsReadOnly => true;

        public bool IsFixedSize => false;

        public int Count => _MessageLog.Count();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object this[int index] { get => _MessageLog[index]; set => _MessageLog[index] = (LogMessage)value; }
        public object AddNew()
        {
            throw new NotImplementedException();
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _MessageLog.Clear();
        }

        public int IndexOf(object value)
        {
           return _MessageLog.IndexOf((LogMessage)value);
        }

        public void Insert(int index, object value)
        {
            _MessageLog.Insert(index, (LogMessage)value);
        }

        public void Remove(object value)
        {
            _MessageLog.Remove((LogMessage)value);
        }

        public void RemoveAt(int index)
        {
            _MessageLog.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
