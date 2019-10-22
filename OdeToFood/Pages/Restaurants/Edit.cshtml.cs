using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class Edit : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public Edit(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this._restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
            this._htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            
            if (Restaurant == null) return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            Restaurant = Restaurant.Id >0 ? _restaurantData.Update(Restaurant) : _restaurantData.Add(Restaurant);
            _restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Details", new {restaurantId = Restaurant.Id});
        }
    }
}