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
    public interface ICourtsRepository : IRepository<Court>
    {
        Task<CourtDto> Add(Court court);
        List<CourtDto> GetAll(int userId);
        List<CourtDto> GetCourtsWithWorkingHours(int userId);
        List<CourtDto> Search(CourtDto courtDto);
    }
}
