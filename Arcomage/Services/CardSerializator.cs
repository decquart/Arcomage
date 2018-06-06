using Arcomage.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Services
{
    public static class CardSerializator
    {
        public static ICollection<Card> GetCardsFromJson()
        {            
            return JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("Configs/Cards.json"));
        }
    }
}
