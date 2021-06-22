namespace ExpressoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        Image = c.String(),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SubMenuId)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        TotalPeople = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "Menu_Id" });
            DropTable("dbo.Reservations");
            DropTable("dbo.SubMenus");
            DropTable("dbo.Menus");
        }
    }
}
