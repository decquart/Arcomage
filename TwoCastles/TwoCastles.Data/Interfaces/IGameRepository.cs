using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.Data.Interfaces
{
    public interface IGameRepository
    {
        bool Exist(string key);
        Game GetGame(string key);
        Game CreateNewGame(string key);
        bool Update(string key, Game game);
        bool Remove(string key);
    }
}
