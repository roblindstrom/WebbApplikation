﻿using FluentValidation;
using RestaurantReview.Domain.IRepositories;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantReview.Application.Features.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>


    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantCommandValidator(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;

            RuleFor(p => p.RestaurantName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                    .MinimumLength(3).WithMessage("{PropertyName} must contain at least 3 characters.");


            RuleFor(e => e)
                .MustAsync(IsRestaurantUnique)
                .WithMessage("A Restaurant with the same name already exists.");

        }
        private async Task<bool> IsRestaurantUnique(CreateRestaurantCommand e, CancellationToken token)
        {
            return !(await _restaurantRepository.IsRestaurantUnique(e.RestaurantName));
        }
    }
}