namespace PolicyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CustomerAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.CustomerAddress_Id)
                .Index(t => t.CustomerAddress_Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PolicyNumber = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        InsuredCustomer_Id = c.Int(),
                        InsuredRiskEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.InsuredCustomer_Id)
                .ForeignKey("dbo.RiskEntities", t => t.InsuredRiskEntity_Id)
                .Index(t => t.InsuredCustomer_Id)
                .Index(t => t.InsuredRiskEntity_Id);
            
            CreateTable(
                "dbo.RiskEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RiskConstruction = c.Int(nullable: false),
                        YearBuilt = c.Int(nullable: false),
                        RiskAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.RiskAddress_Id)
                .Index(t => t.RiskAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "InsuredRiskEntity_Id", "dbo.RiskEntities");
            DropForeignKey("dbo.RiskEntities", "RiskAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Policies", "InsuredCustomer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CustomerAddress_Id", "dbo.Addresses");
            DropIndex("dbo.RiskEntities", new[] { "RiskAddress_Id" });
            DropIndex("dbo.Policies", new[] { "InsuredRiskEntity_Id" });
            DropIndex("dbo.Policies", new[] { "InsuredCustomer_Id" });
            DropIndex("dbo.Customers", new[] { "CustomerAddress_Id" });
            DropTable("dbo.RiskEntities");
            DropTable("dbo.Policies");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
