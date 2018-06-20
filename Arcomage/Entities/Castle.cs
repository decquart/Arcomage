﻿using Arcomage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.Entities
{
    public class Castle : IBuilding
    {
        public int Height { get; set; }
        public int Wall { get; set; }

        //resource
        public int Bricks { get; set; }
        public int Gems { get; set; }
        public int Recruits { get; set; }

        //buildings, which are responsible for resource increaseing
        public int Quarry { get; set; }
        public int Dungeon { get; set; }
        public int Magic { get; set; }


        public void Normalize()
        {
            if (Quarry < 1) Quarry = 1;
            if (Magic < 1) Magic = 1;
            if (Dungeon < 1) Dungeon = 1;

            if (Bricks < 0) Bricks = 0;
            if (Gems < 0) Gems = 0;
            if (Recruits < 0) Recruits = 0;

            if (Wall < 0)
                Wall = 0;
        }
    }
}
