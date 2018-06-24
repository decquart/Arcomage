using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IGameService
    {
        IEnumerable<GameDto> GetGameList();
        GameDto Get(int gameId);
    }
}
