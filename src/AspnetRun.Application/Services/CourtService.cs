using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Mapper;
using AspnetRun.Core.Repositories;
using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtsRepository courtsRepository;
        private readonly MapperConfig _mapperConfig;

        public CourtService(ICourtsRepository courtsRepository, MapperConfig mapperConfig)
        {
            this.courtsRepository = courtsRepository;
            this._mapperConfig = mapperConfig;
        }

        public async Task<CourtDto> Add(CourtDto courtDto)
        {
            var court = _mapperConfig.Mapper().Map<Court>(courtDto);
            return await courtsRepository.Add(court);
        }

        public List<CourtDto> GetAllCourts(int userId)
        {
            return courtsRepository.GetAll(userId);
        }
        public async Task<CourtDto> GetCourt(int courtId, int? userId)
        {
            var court = await courtsRepository.GetAsync(x => x.Id == courtId && (userId == null ? true : x.UserId == userId.Value));
            return _mapperConfig.Mapper().Map<CourtDto>(court.FirstOrDefault());
        }

        public List<CourtDto> GetCourtsWithWorkingHours(int userId)
        {
            return courtsRepository.GetCourtsWithWorkingHours(userId);
        }

    }
}
