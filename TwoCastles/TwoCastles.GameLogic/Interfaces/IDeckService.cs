﻿using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IDeckService
    {
        void Deal(Game game, int amountPlayerCards);
        void GiveCardToPlayer(Game game, Player player);
        void PushCard(Game game, Card card);
        void Shuffle(Game game);
    }
}
