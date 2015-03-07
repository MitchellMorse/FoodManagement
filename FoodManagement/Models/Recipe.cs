using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }
        public int CountUsed { get; set; }
        public decimal PrepTime { get; set; }
        public int PrepTimeTypeId { get; set; }
        public decimal CookTime { get; set; }
        public int CookTimeTypeId { get; set; }
        [ForeignKey("CookType")]
        public int CookTypeId { get; set; }
        
        public virtual TimeType PrepTimeType { get; set; }
        public virtual TimeType CookTimeType { get; set; }
        public virtual CookType CookType { get; set; }
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } 
    }
}