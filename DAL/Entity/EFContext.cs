using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Entity.Identity;

namespace DAL.Entity
{
    public class EFContext : IdentityDbContext<AppUser>, IEFContext
    {
        public EFContext() : base("DefaultConnection")
        {
            Database.SetInitializer<EFContext>(null);
        }

        public static EFContext Create()
        {
            return new EFContext();
        }

        public EFContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<EFContext>(new DBInitializer());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<GeneralInfo> GeneralInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAction> ProductActions { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        //public DbSet<Archive> Archive { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
    }
}
