using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Concrete
{
    public class UserPositionRepository : IUserPositionRepository
    {
        private readonly IEFContext _context;

        public UserPositionRepository(IEFContext context)
        {
            _context = context;
        }

        public IEnumerable<UserPosition> GetAllPositions()
        {
            return _context.Set<UserPosition>();
        }
    }
}
