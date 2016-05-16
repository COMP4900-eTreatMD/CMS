namespace eTreatMD.Migrations.CMSMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorLists",
                c => new
                    {
                        locationID = c.Int(nullable: false, identity: true),
                        rankingOrder = c.Int(nullable: false),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.locationID);
            
            CreateTable(
                "dbo.HospitalLists",
                c => new
                    {
                        locationID = c.Int(nullable: false, identity: true),
                        rankingOrder = c.Int(nullable: false),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.locationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        locationID = c.Int(nullable: false, identity: true),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.locationID);
            
            CreateTable(
                "dbo.PharmacyLists",
                c => new
                    {
                        locationID = c.Int(nullable: false, identity: true),
                        rankingOrder = c.Int(nullable: false),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.locationID);
            
            CreateTable(
                "dbo.PhysiotherapistLists",
                c => new
                    {
                        locationID = c.Int(nullable: false, identity: true),
                        rankingOrder = c.Int(nullable: false),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.locationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhysiotherapistLists");
            DropTable("dbo.PharmacyLists");
            DropTable("dbo.Locations");
            DropTable("dbo.HospitalLists");
            DropTable("dbo.DoctorLists");
        }
    }
}
