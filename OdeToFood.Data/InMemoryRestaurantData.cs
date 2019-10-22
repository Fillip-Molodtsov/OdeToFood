using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1,Name = "Rosan", Location = "NY", CuisineType = CuisineType.American},
                new Restaurant {Id = 2,Name = "McMyller", Location = "NY", CuisineType = CuisineType.American},
                new Restaurant {Id = 3,Name = "Susan", Location = "NY", CuisineType = CuisineType.American}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from restaurant in Restaurants
                where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                orderby restaurant?.Name
                select restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updated)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == updated.Id);
            if (restaurant == null) return restaurant;
            
            restaurant.Name = updated.Name;
            restaurant.Location = updated.Location;
            restaurant.CuisineType = updated.CuisineType;

            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var res = Restaurants.FirstOrDefault(r => r.Id == id);
            if (res != null)
            {
                Restaurants.Remove(res);
            }

            return res;
        }

        public int GetCount()
        {
            return Restaurants.Count();
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}