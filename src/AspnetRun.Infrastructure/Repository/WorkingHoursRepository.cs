using AspnetRun.Core.Entities;
using AspnetRun.Core.Mapper;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class WorkingHoursRepository : Repository<WorkingHour>, IWorkingHoursRepository
    {
        protected readonly MapperConfig _configuration;
        public WorkingHoursRepository(appContext dbContext, MapperConfig configuration) : base(dbContext)
        {
            _configuration = configuration;
        }

        public async Task<WorkinghourDto> AddAsync(WorkinghourDto workinghourDto)
        {
            var workingHour = _configuration.Mapper().Map<WorkingHour>(workinghourDto);
            var workingHourEntity = await base.AddAsync(workingHour);
            return _configuration.Mapper().Map<WorkinghourDto>(workingHourEntity);
        }
    }
}
