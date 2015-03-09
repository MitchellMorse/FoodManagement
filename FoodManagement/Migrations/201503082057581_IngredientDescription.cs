namespace FoodManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IngredientDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredient", "Description");
        }
    }
}
