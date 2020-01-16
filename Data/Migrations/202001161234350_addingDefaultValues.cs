namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDefaultValues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Puestos", "IsAvailable", c => c.Boolean(nullable: false,
                defaultValue: true));
            AlterColumn("dbo.Empleados", "FechaIngreso", c => c.DateTime(nullable: false, defaultValueSql: "GetDate()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleados", "FechaIngreso", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Puestos", "IsAvailable", c => c.Boolean(nullable: false));
        }
    }
}
