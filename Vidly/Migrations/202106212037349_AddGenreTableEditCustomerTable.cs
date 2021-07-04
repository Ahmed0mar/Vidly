namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTableEditCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateReleased", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "GenereId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "GenereId");
            DropColumn("dbo.Movies", "DateReleased");
            DropColumn("dbo.Movies", "DateAdded");
            DropTable("dbo.Genres");
        }
    }
}
