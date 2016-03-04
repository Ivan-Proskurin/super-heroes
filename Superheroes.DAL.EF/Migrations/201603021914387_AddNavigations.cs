namespace Superheroes.DA.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Superheroes", "Image_FileId", c => c.Int());
            AddColumn("dbo.SuperheroTalents", "Image_FileId", c => c.Int());
            CreateIndex("dbo.Superheroes", "Image_FileId");
            CreateIndex("dbo.SuperheroTalents", "Image_FileId");
            AddForeignKey("dbo.Superheroes", "Image_FileId", "dbo.DbFiles", "FileId");
            AddForeignKey("dbo.SuperheroTalents", "Image_FileId", "dbo.DbFiles", "FileId");
            DropColumn("dbo.Superheroes", "PictureFileId");
            DropColumn("dbo.SuperheroTalents", "PictureFileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuperheroTalents", "PictureFileId", c => c.Int(nullable: false));
            AddColumn("dbo.Superheroes", "PictureFileId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SuperheroTalents", "Image_FileId", "dbo.DbFiles");
            DropForeignKey("dbo.Superheroes", "Image_FileId", "dbo.DbFiles");
            DropIndex("dbo.SuperheroTalents", new[] { "Image_FileId" });
            DropIndex("dbo.Superheroes", new[] { "Image_FileId" });
            DropColumn("dbo.SuperheroTalents", "Image_FileId");
            DropColumn("dbo.Superheroes", "Image_FileId");
        }
    }
}
