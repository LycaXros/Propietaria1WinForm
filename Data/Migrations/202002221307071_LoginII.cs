namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginII : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "RecomiendaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidatos", "RecomiendaId");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropIndex("dbo.Candidatos", new[] { "RecomiendaId" });
            DropColumn("dbo.Candidatos", "RecomiendaId");
        }
    }
}
