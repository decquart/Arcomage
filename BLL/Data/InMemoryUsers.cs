using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Data
{
    public class InMemoryUsers : IUserData
    {
        List<ArcomageUserDTO> currentUsers;

        public InMemoryUsers()
        {
            currentUsers = new List<ArcomageUserDTO>
            {
                new ArcomageUserDTO { Id = "1", Email = "asasaaawe", Name = "Bob", Castle = new DefaultCastleInitializer().Set() },
                new ArcomageUserDTO { Id = "2", Email = "pqwoeapfk", Name = "Petro", Castle = new DefaultCastleInitializer().Set() },
                new ArcomageUserDTO { Id = "3", Email = "NANdlkasljd", Name = "Ivan", Castle = new DefaultCastleInitializer().Set() }
            };
        }

        public ArcomageUserDTO Get(string id)
        {
            return currentUsers.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ArcomageUserDTO> GetAll()
        {
            return currentUsers.OrderBy(u => u.Id);
        }
    }
}
