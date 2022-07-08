using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CourtTypeService : ICourtTypeService
    {
        private readonly ICourtTypeRepository _courtTypeRepository;

        public CourtTypeService(ICourtTypeRepository courtTypeRepository)
        {
            _courtTypeRepository = courtTypeRepository;
        }
        public async Task<List<CourtTypeDto>> GetAll()
        {
            return await _courtTypeRepository.GetCourtsTyps();
        }
        public async Task<CourtTypeDto> GetCourtTypById(int Id)
        {
            return await _courtTypeRepository.GetCourtTypById(Id);
        }
    }
}
