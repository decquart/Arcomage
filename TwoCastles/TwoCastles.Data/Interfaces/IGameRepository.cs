using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.Data.Interfaces
{
    public interface IGameRepository
    {
        Game GetGame();
        Game GetNewGame();
        bool Update(Game game);
    }
}
