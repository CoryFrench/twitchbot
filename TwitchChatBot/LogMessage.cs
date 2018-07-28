using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class LogMessage : INotifyPropertyChanged
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

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public String Message
        {
            get => _Message;
            set
            {
                _Message = value;
                OnPropertyChanged("Message");
            }
        }

        public Level Level
        {
            get => _Level;
            set
            {
                _Level = Level;
                OnPropertyChanged("Level");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
