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
        private static Game Game = new Game();

        public static Game GetGame()
        {
            return Game;
        }

        public static Game GetNewGame()
        {
            Init();
            return Game;
        }

        public static bool Update(Game game)
        {
            if (game == null)
                throw new ArgumentException("Update isn't possible, invalid game argument");
            Game = game;
            return true;
        }

        static Game Init()
        {
            Game.CurrentDeck = new Deck { Cards = new JsonParser().GetCardsFromJson() };
            Game.FirstPlayer = new Player();
            Game.SecondPlayer = new Player();
            CastleInit(Game.FirstPlayer.Castle = new Castle());
            CastleInit(Game.SecondPlayer.Castle = new Castle());

            return Game;
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



