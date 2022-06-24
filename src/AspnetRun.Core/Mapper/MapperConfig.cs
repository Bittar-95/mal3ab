using AspnetRun.Core.Entities;
using AspnetRun.Shared.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Mapper
{
    public class MapperConfig
    {
        public IMapper Mapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Court, CourtDto>().ReverseMap();
                cfg.CreateMap<CourtType, CourtTypeDto>().ReverseMap();
            });
            return configuration.CreateMapper();
        }
    }
}
