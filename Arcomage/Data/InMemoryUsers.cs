using Arcomage.Entities;
using Arcomage.Interfaces;
using Arcomage.Services;
using System.Collections.Generic;
using System.Linq;

namespace Arcomage.Data
{
    public class InMemoryUsers : IUserData
    {
        List<User> currentUsers;

        public InMemoryUsers()
        {
            currentUsers = new List<User>
            {
                new User { Id = 1, Email = "asasaaawe", Name = "Bob", Castle = new DefaultCastleInitializer().Set() },
                new User { Id = 2, Email = "pqwoeapfk", Name = "Petro", Castle = new DefaultCastleInitializer().Set() },
                new User { Id = 3, Email = ",NANdlkasljd", Name = "Ivan", Castle = new DefaultCastleInitializer().Set() }
            };
        }
        
        public User Get(int id)
        {
            return currentUsers.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return currentUsers.OrderBy(u => u.Id);
        }
    }
}
