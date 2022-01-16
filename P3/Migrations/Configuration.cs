namespace P3.Migrations
{
    using System.Data.Entity.Migrations;

    /*Gerado por meio do Package Manager Console: PM> Enable-Migrations*/
    internal sealed class Configuration : DbMigrationsConfiguration<P3.DataContext.MyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "P3.DataContext.MyDataContext";
        }

        protected override void Seed(P3.DataContext.MyDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}