using BLL.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        //create
        Task<IdentityResult> Register(UserDtoForRegister userDTO);
        Task<IdentityResult> Login(UserDtoForRegister userDTO);
        Task<IdentityResult> Logout();

        //read
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmail(string userEmail);
        IEnumerable<UserDTO> GetUsers();

        string GetUserId(ClaimsPrincipal claims);
    }
}
