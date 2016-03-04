namespace Superheroes.DA.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Body = c.Binary(),
                        ContentType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.Superheroes", "PictureFileId", c => c.Int(nullable: false));
            AddColumn("dbo.SuperheroTalents", "PictureFileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperheroTalents", "PictureFileId");
            DropColumn("dbo.Superheroes", "PictureFileId");
            DropTable("dbo.DbFiles");
        }
    }
}
