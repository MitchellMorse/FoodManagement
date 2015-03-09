using FoodManagement.Models;

namespace FoodManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodManagement.DAL.FoodManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodManagement.DAL.FoodManagementContext context)
        {
            context.CookTypes.AddOrUpdate(c => c.Name,
                new CookType() { Name = "Grill" },
                new CookType() { Name = "Bake" },
                new CookType() { Name = "Boil" },
                new CookType() { Name = "Crockpot" }
                );

            context.TimeTypes.AddOrUpdate(t => t.Name,
                new TimeType() { Name = "Second" },
                new TimeType() { Name = "Minute" },
                new TimeType() { Name = "Hour" }
                );

            context.QuantityTypes.AddOrUpdate(q => q.Name,
                new QuantityType() { Name = "Pound" },
                new QuantityType() { Name = "Each" },
                new QuantityType() { Name = "Teaspoon" },
                new QuantityType() { Name = "Tablespoon" },
                new QuantityType() { Name = "Dash" }
                );

            context.Stores.AddOrUpdate(s => s.Name,
                new Store() { Name = "Smiths" },
                new Store() { Name = "Wal-Mart" }
                );

            context.IngredientTypes.AddOrUpdate(i => i.ID,
                new IngredientType() { ID = 1, Name = "Meat" },
                new IngredientType() { ID = 2, Name = "Produce" },
                new IngredientType() { ID = 3, Name = "Dairy" },
                new IngredientType() { ID = 4, Name = "Bread" },
                new IngredientType() { ID = 5, Name = "Cereal" },
                new IngredientType() { ID = 6, Name = "Canned" },
                new IngredientType() { ID = 7, Name = "Frozen" },
                new IngredientType() { ID = 8, Name = "Snack" },
                new IngredientType() { ID = 9, Name = "Spice" }
                );

            context.SaveChanges();

            context.Ingredients.AddOrUpdate(i => new {i.Name, i.Description},
                new Ingredient() {Name = "Mitchell Bread", IngredientTypeID = 4},
                new Ingredient() {Name = "Wheat Bread", IngredientTypeID = 4},
                new Ingredient() {Name = "Apple", IngredientTypeID = 2},
                new Ingredient() {Name = "Banana", IngredientTypeID = 2},
                new Ingredient() {Name = "Plum", IngredientTypeID = 2},
                new Ingredient() {Name = "Peach", IngredientTypeID = 2},
                new Ingredient() {Name = "Pear", IngredientTypeID = 2},
                new Ingredient() {Name = "Green Grapes", IngredientTypeID = 2},
                new Ingredient() {Name = "Purple Grapes", IngredientTypeID = 2},
                new Ingredient() {Name = "Black Grapes", IngredientTypeID = 2},
                new Ingredient() {Name = "Lemon", IngredientTypeID = 2},
                new Ingredient() {Name = "Cherry Tomato", IngredientTypeID = 2},
                new Ingredient() {Name = "Brocolli", IngredientTypeID = 2},
                new Ingredient() {Name = "Green Beans", IngredientTypeID = 2},
                new Ingredient() {Name = "Snap Peas", IngredientTypeID = 2},
                new Ingredient() {Name = "Potatoe", IngredientTypeID = 2},
                new Ingredient() {Name = "Red Potato", IngredientTypeID = 2},
                new Ingredient() {Name = "Sweet Potato", IngredientTypeID = 2},
                new Ingredient() {Name = "Salad", IngredientTypeID = 2},
                new Ingredient() {Name = "Watermellon", IngredientTypeID = 2},
                new Ingredient() {Name = "Baby Carrot", IngredientTypeID = 2},
                new Ingredient() {Name = "Carrot", IngredientTypeID = 2},
                new Ingredient() {Name = "Ham", IngredientTypeID = 1, Description = "Deli"},
                new Ingredient() {Name = "Turkey", IngredientTypeID = 1, Description = "Deli"},
                new Ingredient() {Name = "Hamburger Meat", IngredientTypeID = 1, Description = "80/20"},
                new Ingredient() {Name = "Chicken Breast", IngredientTypeID = 1, Description = "Boneless"},
                new Ingredient() {Name = "Steak", IngredientTypeID = 1, Description = "Sirloin"},
                new Ingredient() { Name = "Steak", IngredientTypeID = 1, Description = "New York Strip" }
                );
        }
    }
}
