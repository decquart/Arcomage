using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Game CreateNewGame(string key)
        {
            return InMemoryStore.CreateNewGame(key);
        }

        public bool Exist(string key)
        {
            return InMemoryStore.Exist(key);
        }

        public Game GetGame(string key)
        {
            return InMemoryStore.Get(key);
        }

        public bool Remove(string key)
        {
            return InMemoryStore.Remove(key);
        }

        public bool Update(string key, Game game)
        {
            return InMemoryStore.Update(key, game);
        }
    }
}
