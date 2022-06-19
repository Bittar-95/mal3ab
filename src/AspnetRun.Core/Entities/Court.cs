using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class Court
    {
        public ulong Id { get; set; }
        public string Name_AR { get; set; }
        public string Name_EN { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string ContactINFO { get; set; }
        public ulong UserId { get; set; }
        public User User { get; set; }

        public ulong CourtTypeId { get; set; }
        public CourtType CourtType { get; set; }

        public WorkingHour WorkingHours { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
