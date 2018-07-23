using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User : IdentityUser
    {     
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
             = new List<Score>();
    }
}
