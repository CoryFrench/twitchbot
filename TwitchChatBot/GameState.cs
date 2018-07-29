using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    public class GameState
    { 
        public enum Type : Int32
        {
            GameStarted = 0,
            RegisteringPlayers,
            GameOver
        }
        public static IReadOnlyList<IGameState> AllStates
        {
            get => new List<IGameState>
            {
                new GameStartedState(),
                new RegisteringPlayersGameState(),
                new GameOverState()
            };
        }
        public static IGameState FromType(Type t)
        {
            return AllStates[(Int32)t];
        }
    }

    class GameStartedState : IGameState
    {
        public GameState.Type Type => GameState.Type.GameStarted;
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
        public GameState.Type Type => GameState.Type.RegisteringPlayers;

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
        public GameState.Type Type => GameState.Type.GameOver;

        public void OnStateEntered(IGame game)
        {
            var encounter = new Encounter(game);
            encounter.Resolve();
            var s = new StringBuilder();
            s.Append("Creatures Alive: ");
            foreach (var c in encounter.PlayersNotDead.Union(encounter.CreaturesNotDead))
            {
                s.Append(c.Name + ", ");
            }
            s.Remove(s.Length - (", ".Length), ", ".Length);
            game.Announce(s.ToString());
        }

        public void Register(IPlayer player, IGame game)
        {
            game.Announce("The next adventure has not yet begun.");
        }
    }
}
