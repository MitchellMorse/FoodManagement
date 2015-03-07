using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FoodManagement.Models;

namespace FoodManagement.DAL
{
    public class FoodManagementContext : DbContext
    {
        public FoodManagementContext() : base("FoodManagementContext")
        {
            
        }

        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<GroceryListIngredient> GroceryListIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<CurrentPrice> CurrentPrices { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<QuantityType> QuantityTypes { get; set; }
        public DbSet<CookType> CookTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<TimeType> TimeTypes { get; set; }

        //prevent table names from being pluralized by EF
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}