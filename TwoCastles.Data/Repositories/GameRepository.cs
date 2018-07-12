using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Game GetGame()
        {
            return InMemoryStore.GetGame();
        }

        public Game GetNewGame()
        {
            return InMemoryStore.GetNewGame();
        }


        public bool Update(Game game)
        {
            return InMemoryStore.Update(game);
        }
    }
}
