using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Interfaces
{
    public interface IDeckService
    {
        void Shuffle();
        void GiveCardToPlayer(string userId);
        void PushCard(Card card);
        void Deal(string firstUserId, string secondUserId);
    }
}
