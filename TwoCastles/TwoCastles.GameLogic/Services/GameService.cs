﻿using System;
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
            return _db.Game.CreateNewGame(key);
        }

        public bool UpdateGameStats(string key, Game game)
        {
            if (game == null)
                throw new ArgumentException("Game is not valid");
            var result = _db.Game.Update(key, game);
            return result ? true : false;
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

        // TODO Change this method
        public void CheckWinner(Game game)
        {
            if (game.FirstPlayer.Castle.Height >= 50 ||
                game.SecondPlayer.Castle.Height <= 0)
            {
                SendScoreToDatabase(game);
                //send game over message
            }

            if (game.SecondPlayer.Castle.Height >= 50 ||
                     game.FirstPlayer.Castle.Height <= 0)
            {
                SendScoreToDatabase(game);
                //send game over message
            }
        }

        private void SendScoreToDatabase(Game game)
        {
            //send data to database https://localhost:44364/api/scores/create
            //todo: replace url to another place
            var url = "https://localhost:44364/api/scores/create";

            var model = new
            {
                Value = CountPlayerScore(game), 
                GameId = game.Id,
                UserId = game.FirstPlayer.Id
            };

            _apiService.Post(url, model);
        }

        private int CountPlayerScore(Game game)
        {
            return game.FirstPlayer.Score - game.SecondPlayer.Score;
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

    }
}
