using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Controllers;

public class ChefController : Controller
{
    public ChefAndDishContext _context;

    public ChefController(ChefAndDishContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs
        .Include(chef => chef.CreatedDishes)
        .ToList();
        return View("Index", AllChefs);
    }

    [HttpGet("/new/chef")]
    public IActionResult ChefForm()
    {
        return View("NewChef");
    }

    [HttpPost("/create/chef")]
    public IActionResult NewChef(Chef newChef)
    {
        _context.Chefs.Add(newChef);
        _context.SaveChanges();

        return Index();
    }

}
