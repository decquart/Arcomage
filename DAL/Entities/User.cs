using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public  HighScore HighScore { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            return await manager.CreateIdentityAsync(this, authenticationType);
        }
    }
}
