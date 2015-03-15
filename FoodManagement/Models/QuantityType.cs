using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Models
{
    public class QuantityType
    {
        public int ID { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Quantity Type Name")]
        public string Name { get; set; }
    }
}
