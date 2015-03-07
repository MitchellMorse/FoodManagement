namespace FoodManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CookType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CurrentPrice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IngredientID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Decimal(precision: 18, scale: 2),
                        QuantityTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID)
                .ForeignKey("dbo.QuantityType", t => t.QuantityTypeID)
                .ForeignKey("dbo.Store", t => t.StoreID)
                .Index(t => t.IngredientID)
                .Index(t => t.StoreID)
                .Index(t => t.QuantityTypeID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        IngredientTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IngredientType", t => t.IngredientTypeID)
                .Index(t => t.IngredientTypeID);
            
            CreateTable(
                "dbo.GroceryListIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroceryListID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroceryList", t => t.GroceryListID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID)
                .ForeignKey("dbo.QuantityType", t => t.QuantityTypeID)
                .Index(t => t.GroceryListID)
                .Index(t => t.IngredientID)
                .Index(t => t.QuantityTypeID);
            
            CreateTable(
                "dbo.GroceryList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ListDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuantityType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IngredientType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID)
                .ForeignKey("dbo.QuantityType", t => t.QuantityTypeID)
                .ForeignKey("dbo.Recipe", t => t.RecipeID)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID)
                .Index(t => t.QuantityTypeID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CountUsed = c.Int(nullable: false),
                        PrepTime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrepTimeTypeId = c.Int(nullable: false),
                        CookTime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CookTimeTypeId = c.Int(nullable: false),
                        CookTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TimeType", t => t.CookTimeTypeId)
                .ForeignKey("dbo.CookType", t => t.CookTypeId)
                .ForeignKey("dbo.TimeType", t => t.PrepTimeTypeId)
                .Index(t => t.PrepTimeTypeId)
                .Index(t => t.CookTimeTypeId)
                .Index(t => t.CookTypeId);
            
            CreateTable(
                "dbo.TimeType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        StepID = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipe", t => t.RecipeID)
                .ForeignKey("dbo.Step", t => t.StepID)
                .Index(t => t.RecipeID)
                .Index(t => t.StepID);
            
            CreateTable(
                "dbo.Step",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Instructions = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentPrice", "StoreID", "dbo.Store");
            DropForeignKey("dbo.CurrentPrice", "QuantityTypeID", "dbo.QuantityType");
            DropForeignKey("dbo.CurrentPrice", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.RecipeIngredient", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeSteps", "StepID", "dbo.Step");
            DropForeignKey("dbo.RecipeSteps", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "PrepTimeTypeId", "dbo.TimeType");
            DropForeignKey("dbo.Recipe", "CookTypeId", "dbo.CookType");
            DropForeignKey("dbo.Recipe", "CookTimeTypeId", "dbo.TimeType");
            DropForeignKey("dbo.RecipeIngredient", "QuantityTypeID", "dbo.QuantityType");
            DropForeignKey("dbo.RecipeIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient", "IngredientTypeID", "dbo.IngredientType");
            DropForeignKey("dbo.GroceryListIngredient", "QuantityTypeID", "dbo.QuantityType");
            DropForeignKey("dbo.GroceryListIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.GroceryListIngredient", "GroceryListID", "dbo.GroceryList");
            DropIndex("dbo.RecipeSteps", new[] { "StepID" });
            DropIndex("dbo.RecipeSteps", new[] { "RecipeID" });
            DropIndex("dbo.Recipe", new[] { "CookTypeId" });
            DropIndex("dbo.Recipe", new[] { "CookTimeTypeId" });
            DropIndex("dbo.Recipe", new[] { "PrepTimeTypeId" });
            DropIndex("dbo.RecipeIngredient", new[] { "QuantityTypeID" });
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeID" });
            DropIndex("dbo.GroceryListIngredient", new[] { "QuantityTypeID" });
            DropIndex("dbo.GroceryListIngredient", new[] { "IngredientID" });
            DropIndex("dbo.GroceryListIngredient", new[] { "GroceryListID" });
            DropIndex("dbo.Ingredient", new[] { "IngredientTypeID" });
            DropIndex("dbo.CurrentPrice", new[] { "QuantityTypeID" });
            DropIndex("dbo.CurrentPrice", new[] { "StoreID" });
            DropIndex("dbo.CurrentPrice", new[] { "IngredientID" });
            DropTable("dbo.Store");
            DropTable("dbo.Step");
            DropTable("dbo.RecipeSteps");
            DropTable("dbo.TimeType");
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.IngredientType");
            DropTable("dbo.QuantityType");
            DropTable("dbo.GroceryList");
            DropTable("dbo.GroceryListIngredient");
            DropTable("dbo.Ingredient");
            DropTable("dbo.CurrentPrice");
            DropTable("dbo.CookType");
        }
    }
}
