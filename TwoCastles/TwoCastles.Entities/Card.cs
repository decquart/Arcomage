using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace TwoCastles.Entities
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrickCost { get; set; }
        public int GemCost { get; set; }
        public int RecruitCost { get; set; }
        public string Colour { get; set; }
        public bool IsPlayAgain { get; set; }
        public List<string> Method { get; set; }
        public List<int> Argument { get; set; }
        public string Url { get; set; }
    }
}
