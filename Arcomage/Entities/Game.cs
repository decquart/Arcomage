using Arcomage.Interfaces;
using Arcomage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public class Game
    {
        public Players Players { get; set; }
        public Deck CurrentDeck { get; set; }
        private IUserData _users;       

        public Game(IUserData users)
        {
            _users = users;
            Players = new Players();            
        }

        public void Initialize()
        {
            Players.CurrentPlayer = _users.Get(1);
            Players.EnemyPlayer = _users.Get(2);
            CurrentDeck = new DeckInitializer(this).Set();
        }

        public void Run()
        {
            Initialize();
            CurrentDeck.Shuffle();
            CurrentDeck.Deal(Players);
            while (true)
            {               
                var card = Players.CurrentPlayer.Hand.FirstOrDefault();
                card.Del(card.Argument);
                var player = Players.CurrentPlayer;
                Console.ReadLine();
            }
        }
    }
}
