using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;

namespace FoodManagement.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }
        [Display(Name = "Number of times used")]
        public int CountUsed { get; set; }
        [Display(Name = "Prep Time")]
        public decimal PrepTime { get; set; }
        [Display(Name = "Prep Time Type")]
        public int PrepTimeTypeId { get; set; }
        [Display(Name = "Cook Time")]
        public decimal CookTime { get; set; }
        [Display(Name = "Cook Time Type")]
        public int CookTimeTypeId { get; set; }
        [ForeignKey("CookType")]
        [Display(Name = "Cook Type")]
        public int CookTypeId { get; set; }
        
        public virtual TimeType PrepTimeType { get; set; }
        public virtual TimeType CookTimeType { get; set; }
        public virtual CookType CookType { get; set; }
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } 
    }
}