namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados");
            //DropForeignKey("dbo.Logins", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropPrimaryKey("dbo.Empleados");
            AlterColumn("dbo.Empleados", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Empleados", "Id");
            AddForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Logins", "EmpleadoId", "dbo.Empleados", "Id");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            //DropForeignKey("dbo.Logins", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados");
            DropPrimaryKey("dbo.Empleados");
            AlterColumn("dbo.Empleados", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Empleados", "Id");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
            //AddForeignKey("dbo.Logins", "EmpleadoId", "dbo.Empleados", "Id");
            AddForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados", "Id", cascadeDelete: true);
        }
    }
}
