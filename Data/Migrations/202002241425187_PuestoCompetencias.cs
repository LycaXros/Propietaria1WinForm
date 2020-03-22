namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuestoCompetencias : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.Empleados", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatosCompetencias", "CompetenciasRefKey", "dbo.Competencias");
            DropIndex("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey" });
            DropIndex("dbo.CandidatosCompetencias", new[] { "CompetenciasRefKey" });
            DropIndex("dbo.Empleados", new[] { "PuestoId" });
            AddColumn("dbo.Competencias", "PuestoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Empleados", "PuestoId", c => c.Int());
            CreateIndex("dbo.Empleados", "PuestoId");
            CreateIndex("dbo.Competencias", "PuestoId");
            AddForeignKey("dbo.Competencias", "PuestoId", "dbo.Puestos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Empleados", "PuestoId", "dbo.Puestos", "Id", cascadeDelete: false);
            DropTable("dbo.CandidatosCompetencias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CandidatosCompetencias",
                c => new
                    {
                        CandidatosRefKey = c.String(nullable: false, maxLength: 128),
                        CompetenciasRefKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidatosRefKey, t.CompetenciasRefKey });
            
            DropForeignKey("dbo.Empleados", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.Competencias", "PuestoId", "dbo.Puestos");
            DropIndex("dbo.Competencias", new[] { "PuestoId" });
            DropIndex("dbo.Empleados", new[] { "PuestoId" });
            AlterColumn("dbo.Empleados", "PuestoId", c => c.Int(nullable: false));
            DropColumn("dbo.Competencias", "PuestoId");
            CreateIndex("dbo.CandidatosCompetencias", "CompetenciasRefKey");
            CreateIndex("dbo.CandidatosCompetencias", "CandidatosRefKey");
            AddForeignKey("dbo.CandidatosCompetencias", "CompetenciasRefKey", "dbo.Competencias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos", "Cedula", cascadeDelete: true);
        }
    }
}
