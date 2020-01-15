namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondBatchModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(maxLength: 15),
                        Nombre = c.String(),
                        PuestoId = c.Int(nullable: false),
                        Departamento = c.String(),
                        RecomiendaId = c.Int(nullable: false),
                        RecomendadoPor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Puestos", t => t.PuestoId, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.RecomendadoPor_Id)
                .Index(t => t.PuestoId)
                .Index(t => t.RecomendadoPor_Id);
            
            CreateTable(
                "dbo.Experiencia_Laboral_Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Empresa = c.String(),
                        PuestoOcupado = c.String(),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        Salario = c.Double(nullable: false),
                        CandidatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.CandidatoId, cascadeDelete: true)
                .Index(t => t.CandidatoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        FechaIngreso = c.DateTime(nullable: false),
                        Departamento = c.String(),
                        PuestoId = c.Int(nullable: false),
                        Salario = c.Double(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Puestos", t => t.PuestoId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CandidatosCompetencias",
                c => new
                    {
                        CandidatosRefKey = c.Int(nullable: false),
                        CompetenciasRefKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidatosRefKey, t.CompetenciasRefKey })
                .ForeignKey("dbo.Candidatos", t => t.CandidatosRefKey, cascadeDelete: true)
                .ForeignKey("dbo.Competencias", t => t.CompetenciasRefKey, cascadeDelete: true)
                .Index(t => t.CandidatosRefKey)
                .Index(t => t.CompetenciasRefKey);
            
            AddColumn("dbo.Capacitaciones", "CandidatoId", c => c.Int(nullable: false));
            AddColumn("dbo.Puestos", "DepartamentoID", c => c.Int(nullable: false));
            AddColumn("dbo.Puestos", "IsAvailable", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Capacitaciones", "CandidatoId");
            CreateIndex("dbo.Puestos", "DepartamentoID");
            AddForeignKey("dbo.Capacitaciones", "CandidatoId", "dbo.Candidatos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Puestos", "DepartamentoID", "dbo.Departamentos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "RecomendadoPor_Id", "dbo.Empleados");
            DropForeignKey("dbo.Candidatos", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.Empleados", "Id", "dbo.Puestos");
            DropForeignKey("dbo.Puestos", "DepartamentoID", "dbo.Departamentos");
            DropForeignKey("dbo.Experiencia_Laboral_Candidato", "CandidatoId", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatosCompetencias", "CompetenciasRefKey", "dbo.Competencias");
            DropForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos");
            DropForeignKey("dbo.Capacitaciones", "CandidatoId", "dbo.Candidatos");
            DropIndex("dbo.CandidatosCompetencias", new[] { "CompetenciasRefKey" });
            DropIndex("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey" });
            DropIndex("dbo.Empleados", new[] { "Id" });
            DropIndex("dbo.Puestos", new[] { "DepartamentoID" });
            DropIndex("dbo.Experiencia_Laboral_Candidato", new[] { "CandidatoId" });
            DropIndex("dbo.Capacitaciones", new[] { "CandidatoId" });
            DropIndex("dbo.Candidatos", new[] { "RecomendadoPor_Id" });
            DropIndex("dbo.Candidatos", new[] { "PuestoId" });
            DropColumn("dbo.Puestos", "IsAvailable");
            DropColumn("dbo.Puestos", "DepartamentoID");
            DropColumn("dbo.Capacitaciones", "CandidatoId");
            DropTable("dbo.CandidatosCompetencias");
            DropTable("dbo.Empleados");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Experiencia_Laboral_Candidato");
            DropTable("dbo.Candidatos");
        }
    }
}
