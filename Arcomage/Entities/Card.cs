using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public delegate void PlayFunction(int amount);

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
        public PlayFunction Del { get; set; }
        public string Method { get; set; }
        public int Argument { get; set; }
    }
}
