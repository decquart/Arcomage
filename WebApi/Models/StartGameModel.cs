using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StartGameModel
    {
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
    }
}
