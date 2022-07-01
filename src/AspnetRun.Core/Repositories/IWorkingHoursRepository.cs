using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IWorkingHoursRepository : IRepository<WorkingHour>
    {
        Task<WorkinghourDto> AddAsync(WorkinghourDto workinghourDto);
    }
}
