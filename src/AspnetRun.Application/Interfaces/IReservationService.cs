using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AspnetRun.Application.Interfaces
{
    public interface IReservationService
    {
        Task<bool> Add(ReservationDto reservation);
        Task<List<ReservationDto>> Get(DateTime reservationDate);
        Task<IPagedList<ReservationDto>> GetReservationsBasedOnCourtId(int courtId, int userId, int pageSize, int pageNumber);
    }
}
