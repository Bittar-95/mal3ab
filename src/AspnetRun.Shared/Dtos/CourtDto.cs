using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspnetRun.Shared.Dtos
{
    public class CourtDto
    {
        public int Id { get; set; }
        public string Name_AR { get; set; }
        public string Name_EN { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        [Range(1, 24)]
        public double SessionTime { get; set; }
        public WorkinghourDto? WorkinghourDto { get; set; }
        public string ContactINFO { get; set; }
        public CourtTypeDto? CourtType { get; set; }
        [Required]
        public int? CourtTypeId { get; set; }

        public int? Take { get; set; } = 10;
        public int? Skip { get; set; } = 0;
        public bool? IsTopSex { get; set; }


    }
}
