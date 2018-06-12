using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Castle Castle { get; set; }
        public List<Card> Hand;
        public User()
        {
            Hand = new List<Card>();
        }
    }
}
