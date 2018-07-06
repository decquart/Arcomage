using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Helpers;

namespace TwoCastles
{
    public class GameInit
    {
        private  Game game = new Game();
        public Game Init()
        {
            game.CurrentDeck = new Deck {Cards = new CardInitializer().GetCardsFromJson()};
            game.FirstPlayer = new Player();
            game.SecondPlayer = new Player();
            CastleInit(game.FirstPlayer.Castle = new Castle());
            CastleInit(game.SecondPlayer.Castle = new Castle());

            return game;
        }

        void CastleInit(Castle castle)
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
