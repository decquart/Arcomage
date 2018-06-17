using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Victories { get; set; }
        public int Defeats { get; set; }

        public Castle Castle { get; set; }
        public List<Card> Hand;
        public UserDTO()
        {
            Hand = new List<Card>();
        }
    }
}
