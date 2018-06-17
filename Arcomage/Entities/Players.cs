using Arcomage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public class Players
    {
        public UserDTO CurrentPlayer { get; set; }
        public UserDTO EnemyPlayer { get; set; }

        public void UpdatePlayerInfo()
        {

        }
    }

   
}
