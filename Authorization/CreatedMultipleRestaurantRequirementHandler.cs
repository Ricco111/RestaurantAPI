﻿using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class CreatedMultipleRestaurantRequirementHandler : AuthorizationHandler<CreatedMultipleRestaurantRequirement>
    {
        private readonly RestaurantDbContext _context;

        public CreatedMultipleRestaurantRequirementHandler(RestaurantDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            CreatedMultipleRestaurantRequirement requirement)
        {
            var userId = int.Parse(context.User.
                FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value);

            var createdRestaurantCount = _context.
                Restaurants
                .Count(r => r.CreatedById == userId);

            if (createdRestaurantCount >= requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
