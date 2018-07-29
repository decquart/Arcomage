using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IGamePipelineService
    {
        void PlayerTurn(Game game, Card playerCard, Player currentPlayer, Player enemyPlayer);
        void ComputerTurn(Game game, Card computerPlayerCard, Player computerPlayer, Player humanPlayer);
        void DiscardTurn(Game game, Card playerCard, Player currentPlayer);
    }
}
