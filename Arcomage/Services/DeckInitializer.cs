using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Services
{
    class DeckInitializer
    {
        private Deck deck = new Deck();
        public Deck Set()
        {
            deck.Cards = CardSerializator.GetCardsFromJson();
            return deck;
        }
    }
}
