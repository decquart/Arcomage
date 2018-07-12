using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _db;
        public GameService(IUnitOfWork db)
        {
            _db = db;
        }


        #region db
        public Game GetCurrentGame()
        {
            return _db.Game.GetGame();
        }

        public Game GetNewGame()
        {
            return _db.Game.GetNewGame();
        }

        public bool UpdateGameStats(Game game)
        {
            if (game == null)
                throw new ArgumentException("Game is not valid");
            var result = _db.Game.Update(game);
            return result ? true : false;
        }

        #endregion

        public void NormalizeCastle(Castle castle)//todo
        {
            if (castle.Quarry < 1) castle.Quarry = 1;
            if (castle.Magic < 1) castle.Magic = 1;
            if (castle.Dungeon < 1) castle.Dungeon = 1;

            if (castle.Bricks < 0) castle.Bricks = 0;
            if (castle.Gems < 0) castle.Gems = 0;
            if (castle.Recruits < 0) castle.Recruits = 0;

            if (castle.Wall < 0)
                castle.Wall = 0;
        }


        // TODO Change this method
        public string CheckWinner(Game game)
        {
            if (game.FirstPlayer.Castle.Height >= 50 ||
                game.SecondPlayer.Castle.Height <= 0)
                return game.FirstPlayer.Id;

            else if (game.SecondPlayer.Castle.Height >= 50 ||
                     game.FirstPlayer.Castle.Height <= 0)
                return game.SecondPlayer.Id;

            return string.Empty;
        }

        public void IncreasePlayerResource(Player player)
        {
            player.Castle.Bricks += player.Castle.Quarry;
            player.Castle.Gems += player.Castle.Magic;
            player.Castle.Recruits += player.Castle.Dungeon;
        }
    }
}
