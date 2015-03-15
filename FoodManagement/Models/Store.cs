using System.ComponentModel.DataAnnotations;

namespace FoodManagement.Models
{
    public class Store
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Store Name")]
        public string Name { get; set; }
    }
}