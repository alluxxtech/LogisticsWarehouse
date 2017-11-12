using Autofac;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class DataModule : Module
    {
        private string _connStr;
        public DataModule(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EFContext(this._connStr))
                .As<IEFContext>().InstancePerRequest();
            builder.RegisterType<CountryRepository>()
                .As<ICountryRepository>().InstancePerRequest();
            builder.RegisterType<CityRepository>()
                .As<ICityRepository>().InstancePerRequest();
            //builder.RegisterType<UserRepository>()
            //    .As<IUserRepository>().InstancePerRequest();
            //builder.RegisterType<AccountIdentityProvider>()
            //    .As<IAccountProvider>().InstancePerRequest();



            base.Load(builder);
        }
    }
}
