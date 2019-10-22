using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class Delete : PageModel
    {
        public IRestaurantData RestaurantData { get; set; }

        public Restaurant Restaurant { get; set; }

        public Delete(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = RestaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = RestaurantData.Delete(restaurantId);
            RestaurantData.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} was deleted";
            return RedirectToPage("./List");
        }
    }
}