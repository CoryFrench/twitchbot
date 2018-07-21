using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

namespace TwitchChatBot
{
    public partial class Form1 : Form
    {
        TwitchClient client = new TwitchClient();
        public Form1()
        {
            InitializeComponent();
                //  initialize line takes username / oauth token, may want to un-automate this going forward
            client.Initialize(new ConnectionCredentials(Properties.Settings.Default.username, Properties.Settings.Default.oauth));
            client.OnConnected += new EventHandler<OnConnectedArgs>(OnConnected);
            client.Connect();
        }


        private void bJoinChannel_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                client.JoinChannel(tbJoinChannel.Text);
                client.OnJoinedChannel += new EventHandler<OnJoinedChannelArgs>(OnJoinedChannel);
            });
        }

        public void OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
                //Fluff
            client.SendMessage(new JoinedChannel(tbJoinChannel.Text), "Bot joined");
        }

        public void OnConnected(object sender, OnConnectedArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                tbIndicator.BackColor = Color.Green;
            });
        }
    }
}
