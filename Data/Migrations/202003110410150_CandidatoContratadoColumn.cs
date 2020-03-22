namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandidatoContratadoColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatos", "Contratado", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatos", "Contratado");
        }
    }
}
