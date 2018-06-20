using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.Services
{
    public class DefaultCastleInitializer
    {
        private Castle castle = new Castle();
        private Wall wall = new Wall();
        public Castle Set()
        {
            castle.Height = 20;
            castle.Wall = wall;
            castle.Wall.Height = 5;

            castle.Bricks = 5;
            castle.Gems = 5;
            castle.Recruits = 5;

            castle.Quarry = 2;
            castle.Magic = 2;
            castle.Dungeon = 2;

            return castle;
        }
    }
}
