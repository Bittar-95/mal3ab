﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtsRepository courtsRepository;

        public CourtService(ICourtsRepository courtsRepository)
        {
            this.courtsRepository = courtsRepository;
        }

        public Task<CourtDto> Add(CourtDto courtDto)
        {
            var court = new Court { };
            return courtsRepository.Add(court);
        }
    }
}