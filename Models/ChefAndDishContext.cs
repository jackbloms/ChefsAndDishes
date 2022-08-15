#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models;

public class ChefAndDishContext : DbContext 
{ 
    public ChefAndDishContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}