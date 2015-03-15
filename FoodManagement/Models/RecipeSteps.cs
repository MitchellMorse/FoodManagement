using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodManagement.Models
{
    public class RecipeSteps
    {
        public int ID { get; set; }
        [ForeignKey("Recipe")]
        [Display(Name = "Recipe")]
        public int RecipeID { get; set; }
        [ForeignKey("Step")]
        [Display(Name = "Step")]
        public int StepID { get; set; }
        public int Order { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Step Step { get; set; }
    }
}