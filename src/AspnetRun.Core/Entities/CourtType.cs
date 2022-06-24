using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class CourtType:Entity
    {
        public string Size { get; set; }
        public string Type_AR { get; set; }
        public string Type_EN { get; set; }
        public Court Court { get; set; }
    }
}
