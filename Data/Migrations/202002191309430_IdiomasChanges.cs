namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdiomasChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatos", "Idioma_Id", "dbo.Idiomas");
            DropForeignKey("dbo.Empleados", "Idioma_Id", "dbo.Idiomas");
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropIndex("dbo.Candidatos", new[] { "Idioma_Id" });
            DropIndex("dbo.Empleados", new[] { "Idioma_Id" });
            CreateTable(
                "dbo.EmpleadosIdiomas",
                c => new
                    {
                        EmpleadoRef = c.Int(nullable: false),
                        IdiomasRef = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpleadoRef, t.IdiomasRef })
                .ForeignKey("dbo.Empleados", t => t.EmpleadoRef, cascadeDelete: true)
                .ForeignKey("dbo.Idiomas", t => t.IdiomasRef, cascadeDelete: true)
                .Index(t => t.EmpleadoRef)
                .Index(t => t.IdiomasRef);
            
            CreateTable(
                "dbo.CandidatosIdiomas",
                c => new
                    {
                        CandidatoRef = c.String(nullable: false, maxLength: 128),
                        IdiomasRef = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidatoRef, t.IdiomasRef })
                .ForeignKey("dbo.Candidatos", t => t.CandidatoRef, cascadeDelete: true)
                .ForeignKey("dbo.Idiomas", t => t.IdiomasRef, cascadeDelete: true)
                .Index(t => t.CandidatoRef)
                .Index(t => t.IdiomasRef);
            
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
            //DropColumn("dbo.Candidatos", "Idioma_Id");
            //DropColumn("dbo.Empleados", "Idioma_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleados", "Idioma_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Candidatos", "Idioma_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropForeignKey("dbo.CandidatosIdiomas", "IdiomasRef", "dbo.Idiomas");
            DropForeignKey("dbo.CandidatosIdiomas", "CandidatoRef", "dbo.Candidatos");
            DropForeignKey("dbo.EmpleadosIdiomas", "IdiomasRef", "dbo.Idiomas");
            DropForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados");
            DropIndex("dbo.CandidatosIdiomas", new[] { "IdiomasRef" });
            DropIndex("dbo.CandidatosIdiomas", new[] { "CandidatoRef" });
            DropIndex("dbo.EmpleadosIdiomas", new[] { "IdiomasRef" });
            DropIndex("dbo.EmpleadosIdiomas", new[] { "EmpleadoRef" });
            DropTable("dbo.CandidatosIdiomas");
            DropTable("dbo.EmpleadosIdiomas");
            CreateIndex("dbo.Empleados", "Idioma_Id");
            CreateIndex("dbo.Candidatos", "Idioma_Id");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Empleados", "Idioma_Id", "dbo.Idiomas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidatos", "Idioma_Id", "dbo.Idiomas", "Id", cascadeDelete: true);
        }
    }
}
