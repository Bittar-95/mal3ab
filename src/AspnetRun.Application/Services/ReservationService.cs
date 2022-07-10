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
    public class ReservationService : IReservationService
    {
        private readonly MapperConfig _mapperConfig;
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(MapperConfig mapperConfig, IReservationRepository reservationRepository)
        {
            _mapperConfig = mapperConfig;
            _reservationRepository = reservationRepository;

        }
        public async Task Add(ReservationDto reservationDto)
        {
            var reservation = _mapperConfig.Mapper().Map<Reservation>(reservationDto);
            await _reservationRepository.Add(reservation);

        }
    }
}
