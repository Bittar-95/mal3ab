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
    public class WorkingHoursService : IWorkingHoursService
    {

        private readonly IWorkingHoursRepository _workingHourRepository;
        private readonly ICourtService _courtService;
        private readonly MapperConfig _configuration;


        public WorkingHoursService(IWorkingHoursRepository workingHourRepository, ICourtService courtService, MapperConfig mapperConfig)
        {
            _workingHourRepository = workingHourRepository;
            _courtService = courtService;
            _configuration = mapperConfig;
        }

        public async Task<WorkinghourDto> AddAsync(WorkinghourDto workingHourDto, int userId)
        {
            var checkOnUserCourt = _courtService.GetAllCourts(userId).Where(c => c.Id == workingHourDto.CourtId);
            if (checkOnUserCourt.Any())
            {
                return await _workingHourRepository.AddAsync(workingHourDto);
            }
            return null;
        }
        public async Task<WorkinghourDto> EditAsync(WorkinghourDto workingHourDto, int userId)
        {
            var checkOnUserCourt = _courtService.GetAllCourts(userId).Where(c => c.Id == workingHourDto.CourtId);
            if (!checkOnUserCourt.Any())
            {
                return null;
            }
            var workingHour = _configuration.Mapper().Map<WorkingHour>(workingHourDto);
            await _workingHourRepository.UpdateAsync(workingHour);
            return workingHourDto;
        }
        public async Task<WorkinghourDto> GetAsync(int courtId)
        {
            var workingHour = await _workingHourRepository.GetAsync(x => x.CourtId == courtId);
            return _configuration.Mapper().Map<WorkinghourDto>(workingHour.FirstOrDefault());
        }
    }
}
