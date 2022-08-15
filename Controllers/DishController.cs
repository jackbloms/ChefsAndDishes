using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Controllers;

public class DishController : Controller
{
    private ChefAndDishContext dbContext;

    public DishController(ChefAndDishContext context)
    {
        dbContext = context;
    }

    [HttpGet("/dishes")]
    public IActionResult DishDisplay()
    {
        List<Dish> AllDishes = dbContext.Dishes
        .Include(dish => dish.Cook)
        .ToList();
        return View("DishDisplay", AllDishes);
    }

    [HttpGet("/dishes/new")]
    public IActionResult DishesForm()
    {
        ViewBag.AllChefs = dbContext.Chefs.ToList();
        return View("NewDish");
    }

    [HttpPost("/dishes/create")]
    public IActionResult NewDish(Dish newDish)
    {
        dbContext.Dishes.Add(newDish);
        dbContext.SaveChanges();
        return RedirectToAction("DishDisplay");
    }


}