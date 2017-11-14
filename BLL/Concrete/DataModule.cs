using Autofac;
using BLL.Abstract;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Entity;
using DAL.Entity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static BLL.Infrastructure.Identity.Service;

namespace BLL.Concrete
{
    public class DataModule : Module
    {
        private string _connStr;
        private IAppBuilder _app;

        public DataModule(string connString, IAppBuilder app)
        {
            _connStr = connString;
            _app = app;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this._connStr))
                .As<IEFContext>().InstancePerRequest();
            builder.Register(ctx =>
            {
                var context = (EFContext)ctx.Resolve<IEFContext>();
                return context;
            }).AsSelf().InstancePerDependency();

            builder.RegisterType<CountryRepository>()
                .As<ICountryRepository>().InstancePerRequest();
            builder.RegisterType<CityRepository>()
                .As<ICityRepository>().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>()
                .As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<AccountProvider>()
                .As<IAccountProvider>().InstancePerRequest();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<AppUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => _app.GetDataProtectionProvider()).InstancePerRequest();
            //builder.RegisterType<UserRepository>()
            //    .As<IUserRepository>().InstancePerRequest();
            //builder.RegisterType<AccountIdentityProvider>()
            //    .As<IAccountProvider>().InstancePerRequest();



            base.Load(builder);
        }
    }
}
