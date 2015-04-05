using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodManagement.Models;

namespace FoodManagement.ViewModels
{
    public class RecipeIngredients
    {
        public Recipe CurrentRecipe { get; set; }
        public IEnumerable<Ingredient> IngredientsForRecipe { get; set; }
        public IEnumerable<Ingredient> UnusedIngredients { get; set; }
    }
}