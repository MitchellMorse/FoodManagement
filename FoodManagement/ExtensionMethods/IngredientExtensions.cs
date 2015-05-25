using FoodManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodManagement.ExtensionMethods
{
    public static class IngredientExtensions
    {
        public static IEnumerable<Ingredient> SortList(this IEnumerable<Ingredient> ingredients, string sortString)
        {
            switch (sortString)
            {
                case Ingredient._strAscTypeSort:
                    ingredients =
                        ingredients.OrderBy(i => i.IngredientType.Name).ThenBy(i => i.Name);
                    break;
                case Ingredient._strDescTypeSort:
                    ingredients =
                        ingredients.OrderByDescending(i => i.IngredientType.Name).ThenBy(i => i.Name);
                    break;
                case Ingredient._strDescNameSort:
                    ingredients =
                        ingredients.OrderByDescending(i => i.Name).ThenBy(i => i.IngredientType.Name);
                    break;
                default:
                    ingredients =
                        ingredients.OrderBy(i => i.Name).ThenBy(i => i.IngredientType.Name);
                    break;
            }

            return ingredients;
        }

        public static IEnumerable<Ingredient> ApplyFilter(this IEnumerable<Ingredient> ingredients, string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                ingredients =
                    ingredients.Where(i => i.Name.ToUpper().Contains(filter.ToUpper()));
            }

            return ingredients;
        }
    }
}