using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Services
{
     class DefaultCastleInitializer
    {
        private Castle castle;
        public Castle Set()
        {
            castle.Height = 20;
            castle.Wall.Height = 5;

            castle.Bricks = 5;
            castle.Gems = 5;
            castle.Recruits = 5;

            castle.Quarry = 2;
            castle.Magic = 2;
            castle.Recruits = 2;

            return castle;
        }

    }
}
