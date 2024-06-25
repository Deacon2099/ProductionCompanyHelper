namespace ProductionCompanyHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TransportCost = c.Double(nullable: false),
                        CostOfWorkingHour = c.Double(nullable: false),
                        SearchHistory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_Id)
                .Index(t => t.SearchHistory_Id);
            
            CreateTable(
                "dbo.SearchHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        ModuleName1 = c.String(),
                        ModuleName2 = c.String(),
                        ModuleName3 = c.String(),
                        ModuleName4 = c.String(),
                        Description = c.String(),
                        ProductionCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        AssemblyTime = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Description = c.String(),
                        SearchHistory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchHistories", t => t.SearchHistory_Id)
                .Index(t => t.SearchHistory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "SearchHistory_Id", "dbo.SearchHistories");
            DropForeignKey("dbo.Cities", "SearchHistory_Id", "dbo.SearchHistories");
            DropIndex("dbo.Modules", new[] { "SearchHistory_Id" });
            DropIndex("dbo.Cities", new[] { "SearchHistory_Id" });
            DropTable("dbo.Modules");
            DropTable("dbo.SearchHistories");
            DropTable("dbo.Cities");
        }
    }
}
