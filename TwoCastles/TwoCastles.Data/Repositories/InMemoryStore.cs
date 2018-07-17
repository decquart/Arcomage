using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Helper;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    internal static class InMemoryStore
    {
        private static Dictionary<string, Game> Games = new Dictionary<string, Game>();

        public static bool Exist(string key)
        {
            return Games.ContainsKey(key);
        }

        public static Game Get(string key)
        {
            if (!Games.ContainsKey(key))
                throw new ApplicationException($"A game with key: '{key}' doesn't exist");
            return Games[key];
        }

        //create, init, add to dictionary and return game instance
        public static Game CreateNewGame(string key)
        {
            if (Games.ContainsKey(key))
                throw new ApplicationException($"A game with key: '{key}' already exist");
            Game game = new Game().Init(key);

            Games.Add(key, game);
            return game;
        }

        public static bool Update(string key, Game game)
        {
            if (!Games.ContainsKey(key))
                throw new ApplicationException($"A game with key: '{key}' doesn't exist");
            if(game == null)
                throw new ArgumentException($"Game is not valid");

            Games[key] = game;
            return true;
        }
        

        public static bool Remove(string key)
        {
            if(!Games.ContainsKey(key))
                throw new ApplicationException($"A game with key: '{key}' doesn't exist");

            return Games.Remove(key);
        }


        static Game Init(this Game _game, string key)
        {
            _game.CurrentDeck = new Deck { Cards = new JsonParser().GetCardsFromJson() };
            _game.FirstPlayer = new Player()  { Id = key };
            _game.SecondPlayer = new Player() { Id = "AI"};
            CastleInit(_game.FirstPlayer.Castle = new Castle());
            CastleInit(_game.SecondPlayer.Castle = new Castle());

            return _game;
        }

        static void CastleInit(Castle castle)
        {
            castle.Height = 20;
            castle.Wall = 5;

            castle.Bricks = 5;
            castle.Gems = 5;
            castle.Recruits = 5;

            castle.Quarry = 2;
            castle.Magic = 2;
            castle.Dungeon = 2;
        }
    }
}



