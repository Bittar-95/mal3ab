using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class Reservation : Entity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
