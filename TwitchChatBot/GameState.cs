using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class GameStartedState : IGameState
    {
        public void OnStateEntered(IGame game)
        {
            game.Announce("A new adventure is beginning!");
            game.State = new RegisteringPlayersGameState();
        }

        public void Register(IPlayer player, IGame game)
        {
            game.Announce("Player registration will begin shortly");
        }
        
    }

    class RegisteringPlayersGameState : IGameState
    {
        static int SecondsPerEncounter = 30;

        Timer _Timer = null;
        public void OnStateEntered(IGame game)
        {
            game.Announce("Player registration has begun!");

            _Timer = new Timer((e) =>
            {
                game.State = new GameOverState();
                try
                {
                    _Timer.Dispose();
                }
                catch { };
            }, null, TimeSpan.FromSeconds(SecondsPerEncounter), TimeSpan.Zero);
        }

        public void Register(IPlayer player, IGame game)
        {
            game.AddPlayer(player);
            game.Announce(player.Name + " has joined the adventure!");
        }
    }

    class GameOverState : IGameState
    {
        public void OnStateEntered(IGame game)
        {
            game.End();
        }

        public void Register(IPlayer player, IGame game)
        {
            game.Announce("The next adventure has not yet begun.");
        }
    }
}
