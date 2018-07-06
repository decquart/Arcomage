using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    internal static class InMemoryStore
    {
        private static Game Game = new Game();

        public static Game GetGame()
        {
            return Game;
        }

        public static bool Update(Game game)
        {
            if (game == null)
                throw new ArgumentException("Update isn't possible, invalid game argument");
            Game = game;
            return true;
        }
    }
}



