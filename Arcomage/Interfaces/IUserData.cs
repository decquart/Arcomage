using Arcomage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Interfaces
{
    public interface IUserData
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(string id);
    }
}
