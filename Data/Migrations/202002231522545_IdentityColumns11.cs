namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityColumns11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados");
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropPrimaryKey("dbo.Empleados");
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            AlterColumn("dbo.Empleados", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Empleados", "Id");
            AddForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados");
            DropForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados");
            DropForeignKey("dbo.Logins", "EmpleadoId", "dbo.Empleados");
            DropIndex("dbo.Logins", new[] { "EmpleadoId" });
            DropPrimaryKey("dbo.Empleados");
            AlterColumn("dbo.Empleados", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Logins");
            AddPrimaryKey("dbo.Empleados", "Id");
            AddForeignKey("dbo.Candidatos", "RecomiendaId", "dbo.Empleados", "Id");
            AddForeignKey("dbo.EmpleadosIdiomas", "EmpleadoRef", "dbo.Empleados", "Id", cascadeDelete: true);
        }
    }
}
