using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IScoreService
    {
        //create
        bool AddScore(string userId, int gameId, int value);

        //read
        IEnumerable<ScoreDtoWithEmail> GetScoresByGame(int gameId);



    }
}
