using BLL.Entities;
using BLL.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DeckInitializer
    {
        private Deck _deck;

        public DeckInitializer()
        {
            _deck = new Deck();
        }
        public Deck Set()
        {
            var cards = new CardInitializer().GetCardsFromJson();
            _deck.Cards = cards;
            return _deck;
        }

        
    }
}
