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
        public string Name { get; set; }
        [ForeignKey("IngredientType")]
        public int IngredientTypeID { get; set; }

        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<CurrentPrice> CurrentPrices { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<GroceryListIngredient> GroceryListIngredients { get; set; } 
    }
}