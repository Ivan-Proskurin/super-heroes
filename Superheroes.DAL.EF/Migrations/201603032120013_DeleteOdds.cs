namespace Superheroes.DA.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOdds : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Superheroes", "Picture");
            DropColumn("dbo.SuperheroTalents", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SuperheroTalents", "Picture", c => c.String(nullable: false));
            AddColumn("dbo.Superheroes", "Picture", c => c.String(nullable: false));
        }
    }
}
