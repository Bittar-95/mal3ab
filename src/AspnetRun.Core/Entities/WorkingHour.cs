using AspnetRun.Core.Entities.Base;
using AspnetRun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class WorkingHour : Entity
    {

        public DayOfWeek? FromDay { get; set; }
        public DayOfWeek? ToDay { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }

    }
}
