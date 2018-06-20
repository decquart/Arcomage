using Arcomage.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arcomage.Interfaces
{
    public interface IUserData
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(string id);
    }
}
