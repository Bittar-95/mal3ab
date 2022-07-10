using AspnetRun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Shared.Dtos
{
    public class ReservationDto
    {
        public int? Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CourtId { get; set; }
        public CourtDto? Court { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ReservationStatus? Status { get; set; }

    }
}
