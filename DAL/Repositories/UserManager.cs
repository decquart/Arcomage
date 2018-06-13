using Arcomage.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserManager : UserManager<User>, IRepository <User, string> 
    {

        private ApplicationContext _db;

        public UserManager(ApplicationContext db)
            :base(new UserStore<User>(db))
        {
            _db = db;
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        public void Delete(string id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _db.Users.Where(predicate);
        }

        public User Get(string id)
        {
            return _db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
    }
}
