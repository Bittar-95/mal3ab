using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Mapper;
using AspnetRun.Core.Repositories;
using AspnetRun.Shared.Dtos;
using AspnetRun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AspnetRun.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly MapperConfig _mapperConfig;
        private readonly IReservationRepository _reservationRepository;
        private readonly IWorkingHoursService _workingHoursService;
        private readonly ICourtService _courtService;
        public ReservationService(MapperConfig mapperConfig, IReservationRepository reservationRepository, IWorkingHoursService workingHoursService, ICourtService courtService)
        {
            _mapperConfig = mapperConfig;
            _reservationRepository = reservationRepository;
            _workingHoursService = workingHoursService;
            _courtService = courtService;

        }
        public async Task<bool> Add(ReservationDto reservationDto)
        {
            var wHours = await _workingHoursService.GetAsync(reservationDto.CourtId);
            var court = await _courtService.GetCourt(reservationDto.CourtId, null);
            reservationDto.To = reservationDto.From;
            reservationDto.To = reservationDto.To.Value.AddMinutes(court.SessionTime);
            var reservations = (await _reservationRepository.GetAsync(r => r.CourtId == reservationDto.CourtId)).Where(x => x.From.Date.Equals(reservationDto.From.Date) && x.From.TimeOfDay == reservationDto.From.TimeOfDay && x.Status != Shared.Enums.ReservationStatus.Cancelled && x.Status != Shared.Enums.ReservationStatus.Pending);
            if (reservations.Any())
            {
                return false;
            }

            if (wHours != null)
            {
                if (DateTime.UtcNow.Date > reservationDto.From.Date)
                {
                    return false;

                }

                if (wHours.FromTime.HasValue && reservationDto.From.TimeOfDay < wHours.FromTime.Value.TimeOfDay)
                {
                    return false;
                }

                if (wHours.ToTime.HasValue && reservationDto.To.Value.TimeOfDay > wHours.ToTime.Value.TimeOfDay)
                {
                    return false;
                }

                if (wHours.FromDay.HasValue && wHours.ToDay.HasValue && !(Enumerable.Range(Math.Min((int)wHours.FromDay.Value, (int)wHours.ToDay.Value), Math.Max((int)wHours.FromDay.Value, (int)wHours.ToDay.Value)).Contains((int)reservationDto.From.DayOfWeek)))
                {
                    return false;
                }

            }
            var reservation = _mapperConfig.Mapper().Map<Reservation>(reservationDto);
            await _reservationRepository.Add(reservation);
            return true;

        }
        public async Task<List<ReservationDto>> Get(DateTime reservationDate)
        {
            var reservation = await _reservationRepository.GetAsync(r => r.From.Date == reservationDate.Date);

            return _mapperConfig.Mapper().Map<List<ReservationDto>>(reservation);


        }
        public async Task<IPagedList<ReservationDto>> GetReservationsBasedOnCourtId(int courtId, int userId, int pageSize, int pageNumber)
        {
            var courts = await _courtService.GetCourt(courtId, userId);
            if (courts == null)
            {
                return null;
            }
            var reservations = _reservationRepository.GetAsync(r => r.CourtId == courtId).Result.ToPagedList(pageNumber, pageSize);
            var resultDto = _mapperConfig.Mapper().Map<List<ReservationDto>>(reservations.ToList());
            return new StaticPagedList<ReservationDto>(resultDto, reservations);
        }

        public void AcceptOrReject(int reservationId, int courtId, int userId, ReservationStatus reservationStatus)
        {
            _reservationRepository.AcceptOrReject(reservationId, courtId, userId, reservationStatus);
        }
    }
}
