namespace EstateProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacts : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.assignmentbuilding",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            staffid = c.Int(),
            //            buildingid = c.Int(),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.building", t => t.buildingid)
            //    .ForeignKey("dbo.users", t => t.staffid)
            //    .Index(t => t.staffid)
            //    .Index(t => t.buildingid);
            
            //CreateTable(
            //    "dbo.building",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 255, unicode: false),
            //            street = c.String(maxLength: 255, unicode: false),
            //            ward = c.String(maxLength: 255, unicode: false),
            //            district = c.String(maxLength: 255, unicode: false),
            //            structure = c.String(maxLength: 255, unicode: false),
            //            numberofbasement = c.Int(),
            //            floorarea = c.Int(),
            //            direction = c.String(maxLength: 255, unicode: false),
            //            levels = c.String(maxLength: 255, unicode: false),
            //            rentprice = c.Int(),
            //            rentpricedescription = c.String(unicode: false, storeType: "text"),
            //            servicefee = c.String(maxLength: 255, unicode: false),
            //            carfee = c.String(maxLength: 255, unicode: false),
            //            motofee = c.String(maxLength: 255, unicode: false),
            //            overtimefee = c.String(maxLength: 255, unicode: false),
            //            waterfee = c.String(maxLength: 255, unicode: false),
            //            electricityfee = c.String(maxLength: 255, unicode: false),
            //            deposit = c.String(maxLength: 255, unicode: false),
            //            payment = c.String(maxLength: 255, unicode: false),
            //            renttime = c.String(maxLength: 255, unicode: false),
            //            decorationtime = c.String(maxLength: 255, unicode: false),
            //            brokeragetee = c.Decimal(precision: 13, scale: 2),
            //            typess = c.String(maxLength: 255, unicode: false),
            //            note = c.String(maxLength: 255, unicode: false),
            //            linkofbuilding = c.String(maxLength: 255, unicode: false),
            //            map = c.String(maxLength: 255, unicode: false),
            //            avatar = c.String(maxLength: 255, unicode: false),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.building_images",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 255, unicode: false),
            //            building_id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.building", t => t.building_id)
            //    .Index(t => t.building_id);
            
            //CreateTable(
            //    "dbo.rentarea",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            value = c.Int(),
            //            buildingid = c.Int(),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.building", t => t.buildingid)
            //    .Index(t => t.buildingid);
            
            //CreateTable(
            //    "dbo.users",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            username = c.String(nullable: false, maxLength: 255, unicode: false),
            //            password = c.String(nullable: false, maxLength: 255, unicode: false),
            //            fullname = c.String(maxLength: 255, unicode: false),
            //            phone = c.String(maxLength: 255, unicode: false),
            //            email = c.String(maxLength: 255, unicode: false),
            //            role = c.String(nullable: false, maxLength: 255, unicode: false),
            //            status = c.Int(nullable: false),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //            image = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.assignmentcustomer",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            staffid = c.Int(),
            //            customerid = c.Int(),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.customer", t => t.customerid)
            //    .ForeignKey("dbo.users", t => t.staffid)
            //    .Index(t => t.staffid)
            //    .Index(t => t.customerid);
            
            //CreateTable(
            //    "dbo.customer",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            fullname = c.String(nullable: false, maxLength: 255, unicode: false),
            //            phone = c.String(nullable: false, maxLength: 255, unicode: false),
            //            email = c.String(nullable: false, maxLength: 255, unicode: false),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.transactions",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            code = c.String(maxLength: 255, unicode: false),
            //            note = c.String(maxLength: 255, unicode: false),
            //            customerid = c.Int(),
            //            createddate = c.DateTime(),
            //            modifieddate = c.DateTime(),
            //            createdby = c.String(maxLength: 255, unicode: false),
            //            modifiedby = c.String(maxLength: 255, unicode: false),
            //            staffid = c.Int(),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.customer", t => t.customerid)
            //    .ForeignKey("dbo.users", t => t.staffid)
            //    .Index(t => t.customerid)
            //    .Index(t => t.staffid);

            CreateTable(
                "dbo.contacts",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    user_id = c.Int(),
                    email = c.String(maxLength: 255, unicode: false),
                    fullname = c.String(maxLength: 255, unicode: false),
                    phone = c.String(maxLength: 255, unicode: false),
                    title = c.String(maxLength: 255, unicode: false),
                    status = c.String(maxLength: 255, unicode: false),
                    messages = c.String(unicode: false),
                    createddate = c.DateTime(),
                    modifieddate = c.DateTime(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.user_id);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.transactions", "staffid", "dbo.users");
            //DropForeignKey("dbo.assignmentcustomer", "staffid", "dbo.users");
            //DropForeignKey("dbo.transactions", "customerid", "dbo.customer");
            //DropForeignKey("dbo.assignmentcustomer", "customerid", "dbo.customer");
            //DropForeignKey("dbo.assignmentbuilding", "staffid", "dbo.users");
            //DropForeignKey("dbo.rentarea", "buildingid", "dbo.building");
            //DropForeignKey("dbo.building_images", "building_id", "dbo.building");
            //DropForeignKey("dbo.assignmentbuilding", "buildingid", "dbo.building");
            //DropIndex("dbo.transactions", new[] { "staffid" });
            //DropIndex("dbo.transactions", new[] { "customerid" });
            //DropIndex("dbo.assignmentcustomer", new[] { "customerid" });
            //DropIndex("dbo.assignmentcustomer", new[] { "staffid" });
            //DropIndex("dbo.rentarea", new[] { "buildingid" });
            //DropIndex("dbo.building_images", new[] { "building_id" });
            //DropIndex("dbo.assignmentbuilding", new[] { "buildingid" });
            //DropIndex("dbo.assignmentbuilding", new[] { "staffid" });
            //DropTable("dbo.transactions");
            //DropTable("dbo.customer");
            //DropTable("dbo.assignmentcustomer");
            //DropTable("dbo.users");
            //DropTable("dbo.rentarea");
            //DropTable("dbo.building_images");
            //DropTable("dbo.building");
            //DropTable("dbo.assignmentbuilding");
        }
    }
}
