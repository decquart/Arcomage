using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.Interfaces
{
    public interface IGameService
    {
        void PlayCard(string userId, string cardName);
        void DiscardCard(string userId, string cardName);
        void SetResultsToScore(string winId, string losId);
        string CheckIfGameIsOver(string id, string oppId);
    }
}
