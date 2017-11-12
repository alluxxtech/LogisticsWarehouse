using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICityRepository : IDisposable
    {
        City Add(City city);
        IQueryable<City> GetAllCities();
        City GetCityByName(string name);
        City GetCityById(int id);
        int TotalCities();
        void SaveChange();
    }
}
