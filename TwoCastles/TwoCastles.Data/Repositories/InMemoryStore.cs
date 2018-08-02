using System;
using System.Collections.Generic;
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

        public static Game CreateNewGame(string key)
        {
            if (Games.ContainsKey(key))
                throw new ApplicationException($"A game with key: '{key}' already exist");
            Game game = new Game();

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
    }
}



