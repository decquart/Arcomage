using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Victories { get; set; }
        public int Defeats { get; set; }        
    }
}
