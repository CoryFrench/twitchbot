using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class Player : IPlayer
    {
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Player(string name)
        {
            Name = name;
        }
    }
}
