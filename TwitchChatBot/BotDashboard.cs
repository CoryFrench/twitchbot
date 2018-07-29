using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchChatBot.Properties;

namespace TwitchChatBot
{
    /// <summary>
    /// A WinForm that gives controls and status info to the bot user
    /// </summary>
    public partial class BotDashboard : Form
    {
        String ChannelTextboxPlaceholder = @"Enter channel to join";
        private ChatBot _ChatBot = new ChatBot();
        private ListBoxLog _Log = null;

        /// <summary>
        /// Creates a new BotDashboard Form
        /// </summary>
        public BotDashboard()
        {
            // Init this (BotDashboard) 
            //   InitializeComponent should almost always be called first from a WinForms subclass
            InitializeComponent();
            //   Load the icon for the Form's non client area and set it
            Icon = Resources.AppIcon;
            int minHeight = 320;
            MinimumSize = tableLayoutPanel1.GetPreferredSize(new Size(0, minHeight));
            
            // Init _Log
            _Log = new ListBoxLog(LogListBox);
            _ChatBot.MessageLogged += new EventHandler<LogMessage>((object o, LogMessage msg) =>
            {
                if (msg != null)
                {
                    _Log.Log(msg.Level, msg.Message);
                }
            });

            // Init JoinChannelTextBox
            JoinChannelTextBox.Text = ChannelTextboxPlaceholder;

            // Init ConnectionIndicatorTextBox
            var connectionColorBinding = new Binding("BackColor", _ChatBot, "IsConnected");
            //   .Format here allows us to do a data binding from the IsConnected prop (bool) to the BackColor prop
            //   (System.Drawing.Color)
            connectionColorBinding.Format += (s, e) => { e.Value = (bool)e.Value ? Color.Green : Color.Red; };
            ConnectionIndicatorTextBox.DataBindings.Add(connectionColorBinding);

            // Init StateSelectionComboBox... this seems dubious.
            var bindingSource = new BindingSource();
            bindingSource.DataSource = GameState.AllStates;
            StateSelectionComboBox.DataSource = bindingSource.DataSource;
            StateSelectionComboBox.DisplayMember = "Name";
            StateSelectionComboBox.ValueMember = "Name";

            // Attach ChatBot as our ViewModel to power our View
            iDashboardModelBindingSource.DataSource = _ChatBot;

            // Connect to Twitch, providing a lambda function to _ChatBot that allows ChatBot to make function calls on
            // this Form's UI Thread.  The lambda is necessary since ChatBot is the ViewModel object we're data binding
            // to (IDashboardModel) from our WinForm Dashboard.
            _ChatBot.Connect(functionForThisThread => Invoke(functionForThisThread));
        }

        private void JoinChannelButton_Click(object sender, EventArgs e)
        {
            _ChatBot.JoinChannel(JoinChannelTextBox.Text);
        }


        // It makes me a little sad that WinForms textboxes don't have support for placeholder text out of the box.  As
        // a UX engineer, I'm implementing a ghetto version for my sanity.
        private void JoinChannelTextBox_Enter(object sender, EventArgs e)
        {
            if (JoinChannelTextBox.Text.Equals(ChannelTextboxPlaceholder))
            {
                JoinChannelTextBox.Text = "";
            }
        }

        private void JoinChannelTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(JoinChannelTextBox.Text))
            {
                JoinChannelTextBox.Text = ChannelTextboxPlaceholder;
            }
        }

        private void ForceState_Click(object sender, EventArgs e)
        {

        }
    }
}
