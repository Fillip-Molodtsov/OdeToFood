using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class List : PageModel
    {
        private IRestaurantData RestaurantData { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }    
        private readonly IConfiguration _config;

        public string Message { get; private set; }

        public List(IConfiguration config, IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
            this._config = config;
        }

        public void OnGet(string searchQuery)
        {
            Message = _config["Message"]+"!";
            Restaurants = RestaurantData.GetRestaurantsByName(searchQuery);
        }
    }
}