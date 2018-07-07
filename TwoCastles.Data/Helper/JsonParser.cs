using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TwoCastles.Entities;

namespace TwoCastles.Data.Helper
{
    public class JsonParser
    {
        public List<Card> GetCardsFromJson()
        {
            var cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("Configs/Cards.json"));

            return cards;
        }
    }
}
