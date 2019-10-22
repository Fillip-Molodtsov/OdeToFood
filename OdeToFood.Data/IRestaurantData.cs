using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updated);

        Restaurant Delete(int id);

        int GetCount();

        Restaurant Add(Restaurant newRestaurant);
        int Commit();
    }
}