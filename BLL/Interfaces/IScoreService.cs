using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IScoreService
    {
        void AddScore(int userId, int gameId, int value);

        
    }
}
