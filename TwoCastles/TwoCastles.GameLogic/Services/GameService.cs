using System;
using System.Collections.Generic;
using System.Linq;
using TwoCastles.Data.Constants;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _db;
        private readonly Random _rnd;
        private readonly IApiService _apiService;


        public GameService(IUnitOfWork db, IApiService apiService)
        {
            _db = db;
            _rnd = new Random();
            _apiService = apiService;
        }

        #region db
        public bool Exist(string key)
        {
            return _db.Game.Exist(key);
        }

        public Game GetCurrentGame(string key)
        {
            return _db.Game.GetGame(key);
        }

        public Game GetNewGame(string key)
        {
            var game = _db.Game.CreateNewGame(key);
            return Init(game, key);
        }

        public bool UpdateGameStats(string key, Game game)
        {
            if (game == null)
                throw new ArgumentException("Game is not valid");
            return _db.Game.Update(key, game);
        }

        public bool DeleteGame(string key)
        {
            return _db.Game.Remove(key);
        }
        
        #endregion

        
        public void NormalizeCastles(Game game)
        {
            var castles = new List<Castle>()
            {
                game.FirstPlayer.Castle,
                game.SecondPlayer.Castle
            };
            
            foreach(var castle in castles)
            {
                if (castle.Quarry < 0) castle.Quarry = 0;
                if (castle.Magic < 0) castle.Magic = 0;
                if (castle.Dungeon < 0) castle.Dungeon = 0;

                if (castle.Bricks < 0) castle.Bricks = 0;
                if (castle.Gems < 0) castle.Gems = 0;
                if (castle.Recruits < 0) castle.Recruits = 0;

                if (castle.Wall < 0)
                    castle.Wall = 0;
            }
        }

        public string EndGameIfWinnerExist(Game game)
        {
            var currentScore = CalculateCurrentPlayerScore(game);

            //win case
            if (game.FirstPlayer.Castle.Height >= ConstantsList.maxCastleHeight ||
                game.SecondPlayer.Castle.Height <= ConstantsList.minCastleHeight)
            {
                SendScoreToDatabase(game, currentScore);
                DeleteGame(game.FirstPlayer.Id);
                return ConstantsList.winCaseMessage + currentScore;
            }

            //lose case
            if (game.SecondPlayer.Castle.Height >= ConstantsList.maxCastleHeight ||
                     game.FirstPlayer.Castle.Height <= ConstantsList.minCastleHeight)
            {
                //divide by coefficient 
                currentScore /= ConstantsList.loseScoreСoefficient;
                SendScoreToDatabase(game, currentScore);
                DeleteGame(game.FirstPlayer.Id);
                return ConstantsList.loseCaseMessage + currentScore;

            }
            return string.Empty;
        }

        private void SendScoreToDatabase(Game game, int score)
        {
            var url = ConstantsList.scoreCreateUrl;

            var model = new
            {
                Value = score, 
                GameId = game.Id,
                UserId = game.FirstPlayer.Id
            };

            _apiService.Post(url, model);
        }

        public int CalculateCurrentPlayerScore(Game game)
        {
            var additionalPlayerScore = 0;
            //added building's values to score
            additionalPlayerScore += (game.FirstPlayer.Castle.Wall -
                                      game.SecondPlayer.Castle.Wall);
            additionalPlayerScore += (game.FirstPlayer.Castle.Height -
                                      game.SecondPlayer.Castle.Height);

            //added resources to score 
            additionalPlayerScore += (game.FirstPlayer.Castle.Bricks -
                                      game.SecondPlayer.Castle.Bricks);
            additionalPlayerScore += (game.FirstPlayer.Castle.Gems -
                                      game.SecondPlayer.Castle.Gems);
            additionalPlayerScore += (game.FirstPlayer.Castle.Recruits -
                                      game.SecondPlayer.Castle.Recruits);

            //added factory's values to score
            additionalPlayerScore += (game.FirstPlayer.Castle.Quarry -
                                      game.SecondPlayer.Castle.Quarry);
            additionalPlayerScore += (game.FirstPlayer.Castle.Magic -
                                      game.SecondPlayer.Castle.Magic);
            additionalPlayerScore += (game.FirstPlayer.Castle.Dungeon -
                                      game.SecondPlayer.Castle.Dungeon);

            //return sum current and additional score
            return game.FirstPlayer.Score + additionalPlayerScore;            
        }

        public void IncreasePlayerResource(Player player)
        {
            player.Castle.Bricks += player.Castle.Quarry;
            player.Castle.Gems += player.Castle.Magic;
            player.Castle.Recruits += player.Castle.Dungeon;
        }

        public Card GetRandomCard(Player player)
        {
            int randomIndex = _rnd.Next(player.Hand.Count);
            return player.Hand[randomIndex];
        }

        public void IncreasePlayerScore(Player player, Card currentCard)
        {
            player.Score += currentCard.BrickCost;
            player.Score += currentCard.GemCost;
            player.Score += currentCard.RecruitCost;
        }


        #region initGame
        private Game Init(Game _game, string key)
        {
            _game.CurrentDeck = new Deck { Cards = _db.Cards.GetAll().ToList() };
            _game.FirstPlayer = new Player() { Id = key };
            _game.SecondPlayer = new Player() { Id = ConstantsList.computerId };
            CastleInit(_game.FirstPlayer.Castle = new Castle());
            CastleInit(_game.SecondPlayer.Castle = new Castle());

            return _game;
        }

        private void CastleInit(Castle castle)
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
        #endregion
    }
}
