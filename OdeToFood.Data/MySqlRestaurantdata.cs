using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class MySqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public MySqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return _db.Restaurants
                .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(r=>r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updated)
        {
            var entity = _db.Restaurants.Attach(updated);
            entity.State = EntityState.Modified;
            return updated;
        }

        public Restaurant Delete(int id)
        {
            var res = GetRestaurantById(id);
            if (res != null)
            {
                _db.Restaurants.Remove(res);
            }

            return res;
        }

        public int GetCount()
        {
            return _db.Restaurants.Count();
        }

        public Restaurant Add(Restaurant newRestaurant)
        { 
            _db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}