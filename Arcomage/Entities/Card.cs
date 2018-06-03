using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    [Serializable]
    class Card
    {
        public string Name { get; }
        public string Description { get; }
        public int BrickCost { get; }
        public int GemCost { get; }
        public int RecruitCost { get; }
        public string Colour { get; }
        public bool IsPlayAgain { get; }
    }
}
