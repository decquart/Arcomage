using Arcomage.Entities;
using Arcomage.Interfaces;
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
                new User { Id = 1, Email = "asasaaawe", Name = "Bob" },
                new User { Id = 1, Email = "pqwoeapfk", Name = "Petro" },
                new User { Id = 1, Email = ",NANdlkasljd", Name = "Ivan" }
            };
        }
        
        public User Get(int id)
        {
            return currentUsers.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return currentUsers.OrderBy(u => u.Name);
        }
    }
}
