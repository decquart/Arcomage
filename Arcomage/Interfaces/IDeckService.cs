using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.Interfaces
{
    public interface IDeckService
    {
        void Shuffle();
        void GiveCardToPlayer(UserDTO user);
        void PushCard(Card card);
        void Deal(string firstUserId, string secondUserId);
    }
}
