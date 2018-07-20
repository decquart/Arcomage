﻿using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IGameService
    {
        Game GetCurrentGame(string key);
        Game GetNewGame(string key);
        bool UpdateGameStats(string key, Game game);
        bool DeleteGame(string key);
        bool Exist(string key);

        void NormalizeCastles(Game game);
        void CheckWinner(Game game);
        void IncreasePlayerResource(Player player);
        Card GetRandomCard(Player player);
    }
}
