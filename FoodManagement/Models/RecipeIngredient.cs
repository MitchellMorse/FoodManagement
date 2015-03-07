using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodManagement.Models
{
    public class RecipeIngredient
    {
        public int ID { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeID { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientID { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("QuantityType")]
        public int QuantityTypeID { get; set; }

        public virtual QuantityType QuantityType { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}