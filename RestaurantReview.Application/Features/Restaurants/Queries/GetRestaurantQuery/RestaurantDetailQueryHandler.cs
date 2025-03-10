﻿using AutoMapper;
using RestaurantReview.Application.Features.Restaurants.Queries.GetRestaurantByNameQuery;
using RestaurantReview.Domain.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReview.Application.Features.Restaurants.Queries.GetRestaurantQuery
{
    public class RestaurantDetailQueryHandler : IRestaurantDetailService
    {
        //Innehåller kod för metoder, Hittar detta genom att kalla på databasen genom Repository

        //Får inte returnera en vanlig "Model" Måste Returner en ResponsTyp med innehållet man vill visa.
        private readonly IMapper _mapper;

        private readonly IRestaurantRepository _restaurantRepository;


        public RestaurantDetailQueryHandler(IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;

        }

        public async Task<RestaurantDetailResponse> GetRestaurantByID(RestaurantDetailCommand RestaurantDetailCommand)
        {
            var Restaurant = await _restaurantRepository.GetByIdAsync(RestaurantDetailCommand.RestaurantID);

            var RestaurantResponse = _mapper.Map<RestaurantDetailResponse>(Restaurant);

            RestaurantResponse.ReviewsDtoResponse = _mapper.Map<List<ReviewDtoResponse>>(Restaurant.Reviews);

            return RestaurantResponse;


        }





    }
}
