using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        //create
        void CreateGame(GameDto game);

        //read
        IEnumerable<GameDto> GetGameList();
        GameDto Get(int gameId);
    }
}
