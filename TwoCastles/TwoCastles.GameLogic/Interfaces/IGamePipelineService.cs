using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IGamePipelineService
    {
        string PlayerTurn(Game game, Card playerCard, Player currentPlayer, Player enemyPlayer);
        string ComputerTurn(Game game, Card computerPlayerCard, Player computerPlayer, Player humanPlayer);
        string DiscardTurn(Game game, Card playerCard, Player currentPlayer);
    }
}
