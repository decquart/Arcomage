using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Helpers
{
    public class CardInitializer
    {
        public List<Card> GetCardsFromJson()
        {
            var cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("Configs/Cards.json"));

            return cards;
        }
    }
}
