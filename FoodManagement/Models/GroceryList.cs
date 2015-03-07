using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Models
{
    public class GroceryList
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "List Date")]
        public DateTime ListDate { get; set; }

        public virtual ICollection<GroceryListIngredient> GroceryListIngredients { get; set; } 
    }
}