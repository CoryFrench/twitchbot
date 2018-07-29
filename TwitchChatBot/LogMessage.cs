using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class LogMessage
    {
        private String _Message = String.Empty;
        private Level _Level = Level.Debug;
        private DateTime _Time;

        public LogMessage(Level level, String message)
        {
            _Time = DateTime.Now;
            _Level = level;
            _Message = message;
        }

        public String Message
        {
            get; set;
        }

        public Level Level
        {
            get; set;
        }
    }
}
