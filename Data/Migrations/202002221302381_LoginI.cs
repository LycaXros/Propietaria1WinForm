namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropForeignKey("dbo.Candidatos", "RecomendadoPor_Id", "dbo.Empleados");
            DropIndex("dbo.Candidatos", new[] { "RecomiendaId" });
            DropIndex("dbo.Candidatos", new[] { "RecomendadoPor_Id" });
            //CreateTable(
            //    "dbo.V_EmployeePuesto",
            //    c => new
            //        {
            //            RowId = c.Guid(nullable: false),
            //            Cedula = c.String(),
            //            Nombre = c.String(),
            //            FechaIngreso = c.DateTime(nullable: false),
            //            Salario = c.Double(nullable: false),
            //            Puesto = c.String(),
            //            Departamento = c.String(),
            //        })
            //    .PrimaryKey(t => t.RowId);

            DropColumn("dbo.Candidatos", "RecomiendaId");
            DropColumn("dbo.Candidatos", "RecomendadoPor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatos", "RecomiendaId", c => c.Int(nullable: false));
            //DropTable("dbo.V_EmployeePuesto");
            CreateIndex("dbo.Candidatos", "RecomiendaId");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
        }
    }
}
