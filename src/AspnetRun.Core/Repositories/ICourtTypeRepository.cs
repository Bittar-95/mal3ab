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
    public interface ICourtTypeRepository : IRepository<CourtType>
    {
        Task<List<CourtTypeDto>> GetCourtsTyps();
        Task<CourtTypeDto> GetCourtTypById(int Id);
    }
}
