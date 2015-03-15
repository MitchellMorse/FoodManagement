using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodManagement.Models
{
    public class RecipeIngredient
    {
        public int ID { get; set; }
        [ForeignKey("Recipe")]
        [Display(Name = "Recipe")]
        public int RecipeID { get; set; }
        [ForeignKey("Ingredient")]
        [Display(Name = "Ingredient")]
        public int IngredientID { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("QuantityType")]
        [Display(Name = "Quantity Type")]
        public int QuantityTypeID { get; set; }

        public virtual QuantityType QuantityType { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}