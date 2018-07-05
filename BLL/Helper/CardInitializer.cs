using BLL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Helper
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
