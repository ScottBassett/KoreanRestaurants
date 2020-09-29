using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Hwa Tong Sam", Location = "Gimcheon", Cuisine = CuisineType.Korean},
                new Restaurant {Id = 2, Name = "Misoya", Location = "Gimcheon", Cuisine = CuisineType.Japanese},
                new Restaurant {Id = 3, Name = "Mom's Touch", Location = "Busan", Cuisine = CuisineType.Chicken},
                new Restaurant {Id = 4, Name = "Yoo Ga Ne", Location = "Seoul", Cuisine = CuisineType.Chicken},
                new Restaurant {Id = 5, Name = "Big Ben", Location = "Daegu", Cuisine = CuisineType.British},
                new Restaurant {Id = 6, Name = "Casual Cafe", Location = "Gimcheon", Cuisine = CuisineType.Korean},
                new Restaurant {Id = 7, Name = "Isaacs", Location = "Gimcheon", Cuisine = CuisineType.Toasty}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Location
                select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);

            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public int Commit()
        {
            return 0;
        }

    }
}