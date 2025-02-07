﻿using System.Threading.Tasks;

namespace RestaurantReview.Application.Features.Restaurants.Commands.DeleteRestaurant
{
    public interface IDeleteRestaurantService
    {
        Task<string> DeleteRestaurant(DeleteRestaurantCommand deleteRestaurantCommand);
    }
}
