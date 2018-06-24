using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ArcomageUserDTO : UserDTO
    {
        public Castle Castle { get; set; }
        public List<Card> Hand;
        public ArcomageUserDTO()
        {
            Hand = new List<Card>();
        }
    }
}
