using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface ICardService
    {
        void Play(Card card, Player currentPlayer, Player enemyPlayer);        
        bool IsEnoughResources(Card card, Player currentPlayer);

    }
}
