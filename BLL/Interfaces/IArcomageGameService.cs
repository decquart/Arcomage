using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IArcomageGameService
    {
        void PlayCard(string userId, string cardName);
        void DiscardCard(string userId, string cardName);
        void SetResultsToScore(string winId, string losId);
        string CheckIfGameIsOver(string id, string oppId);
    }
}
