using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using AspnetRun.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        protected readonly appContext _dbContext;
        public ReservationRepository(appContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Reservation reservation)
        {
            await AddAsync(reservation);
        }
        public void AcceptOrReject(int reservationId, int courtId, int userId, ReservationStatus reservationStatus)
        {

            var reservations = _dbContext.Courts.Include(r => r.Reservations).FirstOrDefault(x => x.UserId == userId && x.Id == courtId)?.Reservations;
            var updatedReservation = reservations.Where(r => r.Id == reservationId).Select(r => { r.Status = (reservationStatus == ReservationStatus.Cancelled) ? ReservationStatus.Cancelled : ReservationStatus.Accepted; return r; }).FirstOrDefault();

            if (reservationStatus == ReservationStatus.Cancelled && updatedReservation is not null)
            {
                var updatedReservations = reservations.Where(r => r.From == updatedReservation.From).Select(r => { r.Status = ReservationStatus.Cancelled; return r; }).ToList();
                updatedReservations.Add(updatedReservation);
                _dbContext.UpdateRange(updatedReservations);
                _dbContext.SaveChanges();
                return;
            }
            if (updatedReservation is not null)
            {
                _dbContext.Update(updatedReservation);
                _dbContext.SaveChanges();
            }

        }
    }
}
