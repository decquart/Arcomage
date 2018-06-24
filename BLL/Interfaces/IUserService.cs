using BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        //create
        Task<IdentityResult> Register(UserDTO userDTO);

        //read
        UserDTO GetUserById(string userId);
        UserDTO GetUserByName(string userName);
        IEnumerable<UserDTO> GetUsers();

        //update
        bool UpdateUserInformation(UserDTO userDTO);

        Task<ClaimsIdentity> OAuthIdentity(string userName, string password);
        Task<ClaimsIdentity> CookiesIdentity(string userName, string password);

        void Dispose();
    }
}
