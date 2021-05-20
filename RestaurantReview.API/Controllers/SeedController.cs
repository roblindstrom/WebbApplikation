﻿using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Application.Features.Seed.Commands.CreateSeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : Controller
    {
        private readonly ICreateSeedService _createSeedService;
        public SeedController(ICreateSeedService createSeedService)
        {
            _createSeedService = createSeedService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateSeed()
        {
            return await _createSeedService.CreateSeed();
        }
    }
}
