
using System.Collections.Generic;

namespace FoodManagement.Models
{
    public class Step
    {
        public int ID { get; set; }
        public string Instructions { get; set; }

        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }
    }
}
