using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(appContext dbContext) : base(dbContext)
        {

        }
        public async Task Add(Reservation reservation)
        {
            await AddAsync(reservation);
        }
    }
}
