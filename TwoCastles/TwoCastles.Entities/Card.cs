using System;
using System.Collections.Generic;

namespace TwoCastles.Entities
{
    [Serializable]
    public class Card
    {
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
