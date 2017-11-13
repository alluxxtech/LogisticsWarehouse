using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Abstract
{
    public interface IStatusRepository
    {
        List<ProductStatus> GetProductStatuses();

        bool AddStatus(ProductStatus status);
    }
}
