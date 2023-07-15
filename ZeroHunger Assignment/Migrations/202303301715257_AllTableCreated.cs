namespace ZeroHunger_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CollectRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequestId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CollectRequestId);
            
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        ResturantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resturants", t => t.ResturantId, cascadeDelete: true)
                .Index(t => t.ResturantId);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        CollectRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.CollectRequestId, cascadeDelete: true)
                .Index(t => t.CollectRequestId);
            
            CreateTable(
                "dbo.Resturants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        Contact = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        Contact = c.String(nullable: false, maxLength: 11),
                        Role = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AssignedRequests", "CollectRequestId", "dbo.CollectRequests");
            DropForeignKey("dbo.CollectRequests", "ResturantId", "dbo.Resturants");
            DropForeignKey("dbo.FoodItems", "CollectRequestId", "dbo.CollectRequests");
            DropIndex("dbo.FoodItems", new[] { "CollectRequestId" });
            DropIndex("dbo.CollectRequests", new[] { "ResturantId" });
            DropIndex("dbo.AssignedRequests", new[] { "CollectRequestId" });
            DropIndex("dbo.AssignedRequests", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Resturants");
            DropTable("dbo.FoodItems");
            DropTable("dbo.CollectRequests");
            DropTable("dbo.AssignedRequests");
        }
    }
}
