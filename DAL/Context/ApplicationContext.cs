using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Arcomage.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<HighScore> HighScore { get; set; }
        public ApplicationContext(string connectionString) : base(connectionString)
        {
            
        }        
    }
}
