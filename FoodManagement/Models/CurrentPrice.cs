using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Models
{
    public class CurrentPrice
    {
        public int ID { get; set; }
        [ForeignKey("Ingredient")]
        [Display(Name = "Ingredient")]
        public int IngredientID { get; set; }
        [ForeignKey("Store")]
        [Display(Name = "Store")]
        public int StoreID { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public decimal? Quantity { get; set; }
        [ForeignKey("QuantityType")]
        [Display(Name = "Quantity Type")]
        public int? QuantityTypeID { get; set; }

        public virtual QuantityType QuantityType { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Store Store { get; set; }
    }
}
