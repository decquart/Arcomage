using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.ArcomageGameInterfaces
{
    public interface IUserData
    {
        IEnumerable<ArcomageUserDTO> GetAll();
        ArcomageUserDTO Get(string id);
    }
}
