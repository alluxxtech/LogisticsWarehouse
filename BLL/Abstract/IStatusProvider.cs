using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Admin;
using DAL.Abstract;

namespace BLL.Abstract
{
    public interface IStatusProvider
    {
        IEnumerable<StatusViewModel> GetModels();

        StatusResult AddStatus(StatusCreateViewModel model);
    }
}
