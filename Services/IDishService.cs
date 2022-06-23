using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        public int Create(int restaurantId, CreateDishDto dto);
        DishDto GetById(int restaurantId, int dishId);
        public List<DishDto> GetAll(int restaurantId);

        public void RemoveAll(int restaurantId);

        public void RemoveSingleDish(int restaurantId, int dishId);
    }
}
