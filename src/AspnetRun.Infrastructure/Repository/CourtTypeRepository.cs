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
    public class CourtTypeRepository : Repository<CourtType>, ICourtTypeRepository
    {
        protected readonly MapperConfig _configuration;
        public CourtTypeRepository(appContext dbContext, MapperConfig configuration) : base(dbContext)
        {
            _configuration = configuration;
        }

        public async Task<List<CourtTypeDto>> GetCourtsTyps()
        {
            var results = await GetAllAsync();
            return _configuration.Mapper().Map<List<CourtTypeDto>>(results);
        }
        public async Task<CourtTypeDto> GetCourtTypById(int Id)
        {
            var results = await GetByIdAsync(Id);
            return _configuration.Mapper().Map<CourtTypeDto>(results);
        }
    }
}
