using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using delicious.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace delicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
             List<Dish> AllDishes = dbContext.Dishes.ToList();
    
			// Get Dishs with the LastName "Jefferson"
			// List<Dish> Jeffersons = dbContext.Dishs.Where(u => u.LastName == "Jefferson");
    		// Get the 5 most recently added Dishs
            // List<Dish> MostRecent = dbContext.Dishs
    		// 	.OrderByDescending(u => u.CreatedAt)
    		// 	.Take(5)
    		// 	.ToList();
			return View(AllDishes);
        }

        [Route("new")]
        [HttpGet]
        public IActionResult New()
        {
			return View("New");
        }

        [Route("process")]
        [HttpPost]
        public RedirectToActionResult New(Dish newDish)
        {
            dbContext.Dishes.Add(newDish);
            dbContext.SaveChanges();
			return RedirectToAction ("Index");
            // Handle your form submission here
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Show(int id)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
			return View(oneDish);
            // Handle your form submission here
        }

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
			return View(oneDish);
            // Handle your form submission here
        }

        [Route("process/{id}")]
        [HttpPost]
        public RedirectToActionResult Editprocess(Dish editDish, int id)
        {
            Dish oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == id);
            oneDish.Name = editDish.Name;
            oneDish.Chef = editDish.Chef;
            oneDish.Tastiness = editDish.Tastiness;
            oneDish.Calories = editDish.Calories;
            oneDish.Description = editDish.Description;
            dbContext.SaveChanges();
			return RedirectToAction ("Index");
            
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Dish RetrievedUser = dbContext.Dishes.SingleOrDefault(dish => dish.DishId == id);
    
            // Then pass the object we queried for to .Remove() on Users
            dbContext.Dishes.Remove(RetrievedUser);
            
            // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
            dbContext.SaveChanges();
            return RedirectToAction ("Index");

        }












    }
}
