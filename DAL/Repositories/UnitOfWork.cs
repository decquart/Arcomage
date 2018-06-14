using Arcomage.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationContext db;
        private UserManager userManager;
        private HighScoreRepository highScore;

        public UnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }

        public UserManager Users
        {
            get
            {
                if (userManager == null)
                    userManager = new UserManager(db)
                    {
                        UserValidator = new UserValidator<User>(userManager)
                        {
                            AllowOnlyAlphanumericUserNames = false,
                            RequireUniqueEmail = true
                        },
                        PasswordValidator = new PasswordValidator
                        {
                            RequiredLength = 6,
                            RequireNonLetterOrDigit = false,
                            RequireDigit = false,
                            RequireLowercase = true,
                            RequireUppercase = false,
                        }
                    };
                return userManager;
            }
        }

        public IRepository<HighScore, int> HighScores
        {
            get
            {
                if (highScore == null)
                    highScore = new HighScoreRepository(db);
                return highScore;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
