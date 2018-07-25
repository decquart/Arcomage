using System;
using System.Collections.Generic;
using TwoCastles.Data.Constants;
using TwoCastles.Data.Helper;
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


        private static Game Init(this Game _game, string key)
        {
            _game.CurrentDeck = new Deck { Cards = new JsonParser().GetCardsFromJson() };
            _game.FirstPlayer = new Player()  { Id = key };
            _game.SecondPlayer = new Player() { Id = ConstantsList.computerId};
            CastleInit(_game.FirstPlayer.Castle = new Castle());
            CastleInit(_game.SecondPlayer.Castle = new Castle());

            return _game;
        }

        private static void CastleInit(Castle castle)
        {
            castle.Height = ConstantsList.castle;
            castle.Wall = ConstantsList.wall;

            castle.Bricks = ConstantsList.bricks;
            castle.Gems = ConstantsList.gems;
            castle.Recruits = ConstantsList.recruits;

            castle.Quarry = ConstantsList.quarry;
            castle.Magic = ConstantsList.magic;
            castle.Dungeon = ConstantsList.dungeon;
        }
    }
}



