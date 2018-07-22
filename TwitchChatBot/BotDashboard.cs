using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchChatBot
{
    /// <summary>
    /// A WinForm that gives controls and status info to the bot user
    /// </summary>
    public partial class BotDashboard : Form
    {
        String ChannelTextboxPlaceholder = @"Enter channel to join";
        TwitchChatBot ChatBot = new TwitchChatBot();

        /// <summary>
        /// Creates a new BotDashboard Form
        /// </summary>
        public BotDashboard()
        {
            InitializeComponent();
            JoinChannelTextBox.Text = ChannelTextboxPlaceholder;
            ChatBot.Connect(this);
        }

        private void JoinChannelButton_Click(object sender, EventArgs e)
        {
            ChatBot.JoinChannel(JoinChannelTextBox.Text);
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

        internal void SetConnectionColor(Color color)
        {
            ConnectionIndicatorTextBox.BackColor = color;
        }
    }
}
