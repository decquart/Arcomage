using Arcomage.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Services
{
    public class CardDelegateInitializator
    {
        private CardFunctions cardFunctions;

        public CardDelegateInitializator(Players players)
        {
            cardFunctions = new CardFunctions(players);
        }

        public void Initialize()
        {
            var concertedCardDictionary = ConcertedCardDictionary();            

            var jsonString = File.ReadAllText("Configs/Cards.json");

            dynamic jsonCardArray = JsonConvert.DeserializeObject(jsonString);

            // it'll be explain later )
            foreach (var jsonItem in jsonCardArray)
            {
                // I decide to use local counter for access "jsonItem.Arguments" instead of Zip, because 
                //compiler does not allow to use it with "dynamic" type
                var counter = 0;    
                foreach (var methodString in jsonItem.Methods)
                {
                    counter++;
                    foreach (var method in concertedCardDictionary)
                    {
                        if (methodString == method.Key)
                            Console.WriteLine("ok!");
                        //TODO 
                    }
                }
            }
            
            Console.ReadLine();
        }


        private Dictionary<string, PlayFunction> ConcertedCardDictionary()
        {
            var dict = new Dictionary<string, PlayFunction>();
            dict.Add("Damage", cardFunctions.Damage);
            dict.Add("AddWall", cardFunctions.AddWall);
            dict.Add("AddMagic", cardFunctions.AddMagic);
            dict.Add("AddDungeon", cardFunctions.AddDungeon);
            dict.Add("AddQuarry", cardFunctions.AddQuarry);
            dict.Add("AddBricks", cardFunctions.AddBricks);
            dict.Add("AddGems", cardFunctions.AddGems);
            dict.Add("AddRecruits", cardFunctions.AddRecruits);
            dict.Add("AddCastle", cardFunctions.AddCastle);

            return dict;
        }
    }
}
