using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserData
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(string id);
    }
}
