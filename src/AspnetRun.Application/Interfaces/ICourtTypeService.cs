using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface ICourtTypeService
    {
        Task<List<CourtTypeDto>> GetAll();
        Task<CourtTypeDto> GetCourtTypById(int Id);
    }
}
