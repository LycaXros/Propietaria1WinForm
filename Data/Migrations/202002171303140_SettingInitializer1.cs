namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingInitializer1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Capacitaciones", "CandidatoId", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos");
            DropForeignKey("dbo.Experiencia_Laboral_Candidato", "CandidatoId", "dbo.Candidatos");
            DropIndex("dbo.Capacitaciones", new[] { "CandidatoId" });
            DropIndex("dbo.Experiencia_Laboral_Candidato", new[] { "CandidatoId" });
            DropIndex("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey" });
            RenameColumn(table: "dbo.Capacitaciones", name: "CandidatoId", newName: "CandidatoCedula");
            RenameColumn(table: "dbo.Experiencia_Laboral_Candidato", name: "CandidatoId", newName: "CandidatoCedula");
            DropPrimaryKey("dbo.Candidatos");
            DropPrimaryKey("dbo.CandidatosCompetencias");
            AlterColumn("dbo.Candidatos", "Cedula", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Capacitaciones", "CandidatoCedula", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Experiencia_Laboral_Candidato", "CandidatoCedula", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CandidatosCompetencias", "CandidatosRefKey", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Candidatos", "Cedula");
            AddPrimaryKey("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey", "CompetenciasRefKey" });
            CreateIndex("dbo.Candidatos", "Cedula", unique: true, name: "CedulaCandidato");
            CreateIndex("dbo.Capacitaciones", "CandidatoCedula");
            CreateIndex("dbo.Experiencia_Laboral_Candidato", "CandidatoCedula");
            //CreateIndex("dbo.Empleados", "Cedula", unique: true, name: "CedulaEmpleado");
            CreateIndex("dbo.CandidatosCompetencias", "CandidatosRefKey");
            AddForeignKey("dbo.Capacitaciones", "CandidatoCedula", "dbo.Candidatos", "Cedula", cascadeDelete: true);
            AddForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos", "Cedula", cascadeDelete: true);
            AddForeignKey("dbo.Experiencia_Laboral_Candidato", "CandidatoCedula", "dbo.Candidatos", "Cedula", cascadeDelete: true);
            DropColumn("dbo.Candidatos", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatos", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Experiencia_Laboral_Candidato", "CandidatoCedula", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos");
            DropForeignKey("dbo.Capacitaciones", "CandidatoCedula", "dbo.Candidatos");
            DropIndex("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey" });
            DropIndex("dbo.Empleados", "CedulaEmpleado");
            DropIndex("dbo.Experiencia_Laboral_Candidato", new[] { "CandidatoCedula" });
            DropIndex("dbo.Capacitaciones", new[] { "CandidatoCedula" });
            DropIndex("dbo.Candidatos", "CedulaCandidato");
            DropPrimaryKey("dbo.CandidatosCompetencias");
            DropPrimaryKey("dbo.Candidatos");
            AlterColumn("dbo.CandidatosCompetencias", "CandidatosRefKey", c => c.Int(nullable: false));
            AlterColumn("dbo.Experiencia_Laboral_Candidato", "CandidatoCedula", c => c.Int(nullable: false));
            AlterColumn("dbo.Capacitaciones", "CandidatoCedula", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidatos", "Cedula", c => c.String(maxLength: 15));
            AddPrimaryKey("dbo.CandidatosCompetencias", new[] { "CandidatosRefKey", "CompetenciasRefKey" });
            AddPrimaryKey("dbo.Candidatos", "Id");
            RenameColumn(table: "dbo.Experiencia_Laboral_Candidato", name: "CandidatoCedula", newName: "CandidatoId");
            RenameColumn(table: "dbo.Capacitaciones", name: "CandidatoCedula", newName: "CandidatoId");
            CreateIndex("dbo.CandidatosCompetencias", "CandidatosRefKey");
            CreateIndex("dbo.Experiencia_Laboral_Candidato", "CandidatoId");
            CreateIndex("dbo.Capacitaciones", "CandidatoId");
            AddForeignKey("dbo.Experiencia_Laboral_Candidato", "CandidatoId", "dbo.Candidatos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidatosCompetencias", "CandidatosRefKey", "dbo.Candidatos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Capacitaciones", "CandidatoId", "dbo.Candidatos", "Id", cascadeDelete: true);
        }
    }
}
