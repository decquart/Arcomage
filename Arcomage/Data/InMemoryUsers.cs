using Arcomage.Entities;
using Arcomage.Interfaces;
using Arcomage.Services;
using System.Collections.Generic;
using System.Linq;

namespace Arcomage.Data
{
    public class InMemoryUsers : IUserData
    {
        List<UserDTO> currentUsers;

        public InMemoryUsers()
        {
            currentUsers = new List<UserDTO>
            {
                new UserDTO { Id = "1", Email = "asasaaawe", Name = "Bob", Castle = new DefaultCastleInitializer().Set() },
                new UserDTO { Id = "2", Email = "pqwoeapfk", Name = "Petro", Castle = new DefaultCastleInitializer().Set() },
                new UserDTO { Id = "3", Email = "NANdlkasljd", Name = "Ivan", Castle = new DefaultCastleInitializer().Set() }
            };
        }
        
        public UserDTO Get(string id)
        {
            return currentUsers.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return currentUsers.OrderBy(u => u.Id);
        }
    }
}
