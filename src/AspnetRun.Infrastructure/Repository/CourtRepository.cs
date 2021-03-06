using AspnetRun.Core.Entities;
using AspnetRun.Core.Mapper;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using AspnetRun.Shared;
using AspnetRun.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class CourtRepository : Repository<Court>, ICourtsRepository
    {
        protected readonly appContext _dbContext;
        protected readonly MapperConfig _configuration;
        public CourtRepository(appContext dbContext, MapperConfig configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<CourtDto> Add(Court court)
        {
            var result = await AddAsync(court);
            return _configuration.Mapper().Map<CourtDto>(result);
        }

        public List<CourtDto> GetAll(int userId)
        {
            var courts = _dbContext.Courts.Include(x => x.CourtType).Where(u => u.UserId == userId).ToList();
            return _configuration.Mapper().Map<List<CourtDto>>(courts);
        }

        public List<CourtDto> GetCourtsWithWorkingHours(int userId)
        {
            var results = from WorkingHours in _dbContext.WorkingHours
                          join Courts in _dbContext.Courts.Where(u => u.UserId == userId) on WorkingHours.CourtId equals Courts.Id
                          select new { Courts, WorkingHours };

            var courtDto = new List<CourtDto>();
            foreach (var result in results)
            {
                result.Courts.WorkingHours = result.WorkingHours;
                var dto = _configuration.Mapper().Map<CourtDto>(result.Courts);
                dto.WorkinghourDto = _configuration.Mapper().Map<WorkinghourDto>(result.WorkingHours);
                courtDto.Add(dto);
            }
            return courtDto;
        }

        public List<CourtDto> Search(CourtDto courtDto)
        {
            //var results = from WorkingHours in _dbContext.WorkingHours
            //              join Courts in _dbContext.Courts on WorkingHours.CourtId equals Courts.Id
            //              join reservation in _dbContext.Reservations on Courts.Id equals reservation.CourtId into r
            //              orderby r.Count()
            //              select new { Courts, WorkingHours, r };

            var results = _dbContext.Courts.Include(w => w.WorkingHours).Include(r => r.Reservations).OrderByDescending(r => r.Reservations.Count()).Include(t => t.CourtType).Skip(courtDto.Skip.Value).Take(courtDto.Take.Value);
            var courts = _configuration.Mapper().Map<List<CourtDto>>(results);

            //foreach (var result in results.ToList().Take(courtDto.Take.Value).Skip(courtDto.Skip.Value))
            //{
            //    var dto = _configuration.Mapper().Map<CourtDto>(result.Courts);
            //    dto.WorkinghourDto = _configuration.Mapper().Map<WorkinghourDto>(result.WorkingHours);
            //    courts.Add(dto);
            //}
            return courts;
        }
    }
}
