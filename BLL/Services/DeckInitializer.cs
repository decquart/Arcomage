using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DeckInitializer
    {
        private Deck _deck = new Deck();
        private CardBehavior cardBehavior;

        public DeckInitializer(Game game)
        {
            cardBehavior = new CardBehavior(game);
        }
        public Deck Set()
        {
            var cards = new CardInitializer().GetCardsFromJson();
            DelegateInitialize(cards);
            _deck.Cards = cards;
            return _deck;
        }

        public void DelegateInitialize(List<Card> cardList)
        {
            var concertedCardDictionary = ConcertedCardDictionary();

            // it'll be explain later )
            foreach (var card in cardList)
            {
                foreach (var keyVal in concertedCardDictionary)
                {
                    if (card.Method == keyVal.Key)
                        card.Del += keyVal.Value;
                }


                //foreach (var methodstring in jsonItem)
                //{
                //    counter++;
                //    foreach (var method in concertedcarddictionary)
                //    {
                //        if (methodstring == method.key)
                //            console.writeline("ss");
                //        //todo 
                //    }
                //}
            }
        }


        private Dictionary<string, PlayFunction> ConcertedCardDictionary()
        {
            var dict = new Dictionary<string, PlayFunction>();
            dict.Add("Damage", cardBehavior.Damage);
            dict.Add("AddWall", cardBehavior.AddWall);
            dict.Add("AddMagic", cardBehavior.AddMagic);
            dict.Add("AddDungeon", cardBehavior.AddDungeon);
            dict.Add("AddQuarry", cardBehavior.AddQuarry);
            dict.Add("AddBricks", cardBehavior.AddBricks);
            dict.Add("AddGems", cardBehavior.AddGems);
            dict.Add("AddRecruits", cardBehavior.AddRecruits);
            dict.Add("AddCastle", cardBehavior.AddCastle);

            return dict;
        }
    }
}
