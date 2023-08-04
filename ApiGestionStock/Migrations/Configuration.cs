namespace ApiGestionStock.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiGestionStock.Models.BdStockExamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApiGestionStock.Models.BdStockExamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Administrateurs.AddOrUpdate(
                new Models.Admin {IdAdmin=1, LoginAdmin = "Admin", MotDePasse = "passer", Role = "admin"}
                );
        }
    }
}
