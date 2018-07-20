using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ScoreModel
    {
        public int Value { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
    }
}
