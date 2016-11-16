namespace MVCSinglePageApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnnualEarnings = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyType_Id = c.Guid(nullable: false),
                        ParentCompany_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyTypes", t => t.CompanyType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.ParentCompany_Id)
                .Index(t => t.CompanyType_Id)
                .Index(t => t.ParentCompany_Id);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ParentCompany_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyType_Id", "dbo.CompanyTypes");
            DropIndex("dbo.Companies", new[] { "ParentCompany_Id" });
            DropIndex("dbo.Companies", new[] { "CompanyType_Id" });
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.Companies");
        }
    }
}
