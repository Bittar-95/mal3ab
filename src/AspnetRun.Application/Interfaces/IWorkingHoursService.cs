using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IWorkingHoursService
    {
        Task<WorkinghourDto> AddAsync(WorkinghourDto workingHourDto, int userId);
        Task<WorkinghourDto> GetAsync(int workingHourId);
        Task<WorkinghourDto> EditAsync(WorkinghourDto workingHourDto, int userId);
    }
}
