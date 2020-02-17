namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Models.RRHHContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Models.RRHHContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\EmployeePuestoView.sql";

            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
        }
    }
}
