using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using DAL.Entity;

namespace DAL.Concrete
{
    public class StatusRepository : IStatusRepository
    { 
        private IEFContext _context;

        public StatusRepository()
        {
            _context = new EFContext();
        }

        public StatusRepository(IEFContext context)
        {
            _context = context;
        }
    
        public List<ProductStatus> GetProductStatuses()
        {
            return _context.Set<ProductStatus>().ToList();
        }

        public bool AddStatus(ProductStatus status)
        {
            try
            {
                _context.Set<ProductStatus>().Add(status);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
