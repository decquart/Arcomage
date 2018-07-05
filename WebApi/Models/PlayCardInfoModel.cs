using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PlayCardInfoModel
    {
        public string CardName { get; set; }
        public string CurrentPlayerId { get; set; }
        public string EnemyPlayerId { get; set; }
    }
}
