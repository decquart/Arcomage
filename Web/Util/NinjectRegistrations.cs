using Arcomage.Interfaces;
using Arcomage.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}
