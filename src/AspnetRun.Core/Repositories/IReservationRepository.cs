using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task Add(Reservation reservation);
        void AcceptOrReject(int reservationId, int courtId, int userId, ReservationStatus reservationStatus);
    }
}
