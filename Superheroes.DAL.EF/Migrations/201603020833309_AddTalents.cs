namespace Superheroes.DA.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTalents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperheroTalents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Details = c.String(),
                        Picture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
            AddColumn("dbo.Superheroes", "HeroLevel", c => c.Int(nullable: false));
            AlterColumn("dbo.Superheroes", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Superheroes", "Picture", c => c.String(nullable: false));
            DropColumn("dbo.Superheroes", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Superheroes", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Superheroes", "Picture", c => c.String());
            AlterColumn("dbo.Superheroes", "Name", c => c.String(maxLength: 30));
            DropColumn("dbo.Superheroes", "HeroLevel");
            DropTable("dbo.SuperheroTalents");
        }
    }
}
