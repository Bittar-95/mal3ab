using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class WorkingHour
    {
        public ulong Id { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public ulong CourtId { get; set; }
        public Court Court { get; set; }

    }
}
