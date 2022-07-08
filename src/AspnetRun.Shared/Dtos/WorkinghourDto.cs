using AspnetRun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Shared.Dtos
{
    public class WorkinghourDto
    {
        public int? Id { get; set; }
        public WeekDays? FromDay { get; set; }
        public WeekDays? ToDay { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public int CourtId { get; set; }


        [DisplayName("All Week days")]
        public bool AllDays { get; set; }
        [DisplayName("24-Hours")]
        public bool AllTimes { get; set; }
    }
}
