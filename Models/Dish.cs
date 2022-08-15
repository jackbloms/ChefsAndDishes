#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;

public class Dish 
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name of Dish")]
    public string DishName { get; set; }

    // [Required(ErrorMessage = "is required")]
    // public string Chef { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(0, 10000)]
    [Display(Name = "# of Calories")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(0,5)]
    public int Tastiness { get; set; }
    
    [Required(ErrorMessage = "is required")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // public List<Chef> CreatedChefs { get; set; } = new List<Chef>();

    /*********************************************************
    Relationship properties below:

    Foreign Keys: -id of a different (foreign) model

    Navigation Property: -data type is related model
    -MUST use the .include for the nav prop data to be in
    included via a SQL JOIN statement

    **********************************************************/
    [Display(Name = "Chef")]
    public int ChefId { get; set; }//needs to match w/ primary key of other model
    public Chef? Cook { get; set; }//1 dish related to each chef

}