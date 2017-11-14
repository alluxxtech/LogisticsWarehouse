using DAL.Abstract;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CityRepository : ICityRepository
    {
        private readonly IEFContext _context;
        public CityRepository(IEFContext context)
        {
            _context = context;
        }
        public City Add(City city)
        {
            _context.Set<City>().Add(city);
            return city;
        }
        public IQueryable<City> GetAllCities()
        {
            return this._context.Set<City>();
        }

        public City GetCityById(int id)
        {
            return this.GetAllCities()
                .SingleOrDefault(c => c.Id == id);
        }

        public City GetCityByName(string name)
        {
            return this.GetAllCities()
                .SingleOrDefault(c => c.Name == name);
        }

        public void SaveChange()
        {
            this._context.SaveChanges();
        }

        public int TotalCities()
        {
            return this.GetAllCities().Count();
        }
        public void Dispose()
        {
            if (this._context != null)
                this._context.Dispose();
        }
    }
}
