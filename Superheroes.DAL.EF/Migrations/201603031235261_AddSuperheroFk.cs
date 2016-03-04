namespace Superheroes.DA.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuperheroFk : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SuperheroTalents", "OwnerId");
            AddForeignKey("dbo.SuperheroTalents", "OwnerId", "dbo.Superheroes", "SuperheroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuperheroTalents", "OwnerId", "dbo.Superheroes");
            DropIndex("dbo.SuperheroTalents", new[] { "OwnerId" });
        }
    }
}
