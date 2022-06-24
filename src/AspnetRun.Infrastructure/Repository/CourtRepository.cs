using AspnetRun.Core.Entities;
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
    public class CourtRepository : Repository<Court>, ICourtsRepository
    {
        public CourtRepository(appContext dbContext) : base(dbContext)
        {
        }
        public async Task<CourtDto> Add(Court court)
        {
            var result = await AddAsync(court);
            return new CourtDto
            {
                Address = result.Address,
                area = result.area,
                city = result.city,
                ContactINFO = result.ContactINFO,
                Lng = result.Lng,
                Lat = result.Lat,
                Name_AR = result.Name_AR,
                Name_EN = result.Name_EN,
                Price = result.Price,
            };
        }
    }
}
