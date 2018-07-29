using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    class GameState
    { 
        public static ICollection<IGameState> AllStates
        {
            get => new List<IGameState>
            {
                new GameStartedState(),
                new RegisteringPlayersGameState(),
                new GameOverState()
            };
        }
    }

    class GameStartedState : IGameState
    {
        public String Name => "Game Started State";

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

        public String Name => "Registering Players State";

        public void OnStateEntered(IGame game)
        {
            game.Announce("Player registration has begun!");

            _Timer = new Timer((e) =>
            {
                if (game.State == this)
                { 
                    game.State = new GameOverState();
                    try
                    {
                        _Timer.Dispose();
                    }
                    catch { };
                }
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
       public String Name => "Game Over State";

        public void OnStateEntered(IGame game)
        {
            Encounter e = new Encounter();
            game.End();
        }

        public void Register(IPlayer player, IGame game)
        {
            game.Announce("The next adventure has not yet begun.");
        }
    }
}
