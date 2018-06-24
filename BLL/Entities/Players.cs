using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Players
    {
        public ArcomageUserDTO CurrentPlayer { get; set; }
        public ArcomageUserDTO EnemyPlayer { get; set; }

        public void UpdatePlayerInfo()
        {

        }
    }
}
