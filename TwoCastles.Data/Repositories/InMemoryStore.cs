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
        private static Game _game = new Game();

        public static Game GetGame()
        {
            return _game;
        }

        public static Game GetNewGame()
        {
            Init();
            return _game;
        }

        public static bool Update(Game game)
        {
            if (game == null)
                throw new ArgumentException("Update isn't possible, invalid game argument");
            _game = game;
            return true;
        }

        static Game Init()
        {
            _game.CurrentDeck = new Deck { Cards = new JsonParser().GetCardsFromJson() };
            _game.FirstPlayer = new Player();
            _game.SecondPlayer = new Player();
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



