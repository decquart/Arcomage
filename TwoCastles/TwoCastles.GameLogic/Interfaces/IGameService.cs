using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IGameService
    {
        Game GetCurrentGame();
        Game GetNewGame();
        bool UpdateGameStats(Game game);
        void NormalizeCastle(Castle castle);
        string CheckWinner(Game game);
        void IncreasePlayerResource(Player player);
    }
}
