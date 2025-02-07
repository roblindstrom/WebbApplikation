﻿using RestaurantReview.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReview.Domain.IRepositories
{
    public interface IRestaurantRepository : IAsyncRepository<Restaurant>
    {
        Task<Restaurant> GetRestaurantByName(string Name);

        Task<int> RestaurantReviewCount(string name);

        Task<List<Restaurant>> IncludeReviews(Guid id);

        Task<bool> IsRestaurantUnique(string name);

        Task<List<Restaurant>> IncludeCategories();

        Task<List<Restaurant>> IncludeEverything();
    }
}
