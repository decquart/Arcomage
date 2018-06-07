using Arcomage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    class Castle : IBuilding
    {
        public int Height { get; set; }

        public int Bricks { get; set; }
        public int Gems { get; set; }
        public int Recruits { get; set; }

        public int Quarry { get; set; }
        public int Dungeon { get; set; }
        public int Magic { get; set; }
    }
}
