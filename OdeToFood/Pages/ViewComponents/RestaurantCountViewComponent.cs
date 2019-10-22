using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        public IRestaurantData RestaurantData { get; set; }

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            return View(RestaurantData.GetCount());
        }
    }
}