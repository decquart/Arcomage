using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public int Victories { get; set; }
        public int Defeats { get; set; }



        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        //{
        //    return await manager.CreateIdentityAsync(this, authenticationType);
        //}
    }
}
