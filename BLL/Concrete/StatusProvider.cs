using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstract;
using BLL.Models.Admin;
using DAL.Abstract;
using DAL.Concrete;
using DAL.Entity;

namespace BLL.Concrete
{
    public class StatusProvider : IStatusProvider
    {
        private readonly IStatusRepository _statusRepository;

        public StatusProvider()
        {
            _statusRepository = new StatusRepository();
        }

        public StatusProvider(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public IEnumerable<StatusViewModel> GetModels()
        {
            return _statusRepository.GetProductStatuses().Select(st => new StatusViewModel {Id = st.Id, Name = st.Name });
        }

        public StatusResult AddStatus(StatusCreateViewModel model)
        {
            var result = _statusRepository.AddStatus(new ProductStatus {Name = model.Name});
            return result ? StatusResult.Success : StatusResult.Failure;
        }
    }
}
