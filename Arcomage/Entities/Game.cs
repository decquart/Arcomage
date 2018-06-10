using Arcomage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public class Game
    {
        public Players Players { get; set; }

        public void Run()
        {
            var cardDelInit = new CardDelegateInitializator(this.Players);
        }
    }
}
