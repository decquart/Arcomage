using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Interfaces
{
    interface IUserData
    {
        IEnumerable<User> GetAll();
        User Get(int id);
    }
}
