using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class Details : PageModel
    {
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }
        private IRestaurantData RestaurantData { get; set; }
        
        public Details(IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = this.RestaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null) return RedirectToPage("./NotFound");
            return Page();
        }
    }
}