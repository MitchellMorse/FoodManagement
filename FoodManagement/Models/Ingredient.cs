using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Ingredient Name")]
        public string Name { get; set; }
        [ForeignKey("IngredientType")]
        [Display(Name = "Ingredient Type")]
        public int IngredientTypeID { get; set; }
        public string Description { get; set; }

        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<CurrentPrice> CurrentPrices { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<GroceryListIngredient> GroceryListIngredients { get; set; } 
    }
}