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
            context.CookTypes.AddOrUpdate(c => c.ID,
                new CookType() { ID = 1, Name = "Grill" },
                new CookType() { ID = 2, Name = "Bake" },
                new CookType() { ID = 3, Name = "Boil" },
                new CookType() { ID = 4, Name = "Crockpot" }
                );

            context.TimeTypes.AddOrUpdate(t => t.ID,
                new TimeType() { ID = 1, Name = "Second" },
                new TimeType() { ID = 2, Name = "Minute" },
                new TimeType() { ID = 3, Name = "Hour" }
                );

            context.QuantityTypes.AddOrUpdate(q => q.ID,
                new QuantityType() { ID = 1, Name = "Pound" },
                new QuantityType() { ID = 2, Name = "Each" },
                new QuantityType() { ID = 3, Name = "Teaspoon" },
                new QuantityType() { ID = 4, Name = "Tablespoon" },
                new QuantityType() { ID = 5, Name = "Dash" }
                );

            context.Stores.AddOrUpdate(s => s.ID,
                new Store() { ID = 1, Name = "Smiths" },
                new Store() { ID = 2, Name = "Wal-Mart" }
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
        }
    }
}
