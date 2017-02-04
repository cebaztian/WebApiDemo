namespace WebApiDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiDemo.Models.WebApiDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiDemo.Models.WebApiDemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Doctors.AddOrUpdate(d => d.Id, new Models.Doctor() { Name= "Dr. Nick", Gender=true, LastName= "Riviera", Specialty = "orthopedics" });
            context.Patients.AddOrUpdate(d => d.Id, new Models.Patient() { Name= "Homero", Gender=true, LastName= "Simpson", Address="Avenida siempre viva 123", Age=54, Job="Técnico nuclear" });
            context.Medicines.AddOrUpdate(d => d.Id, new Models.Medicine() { Name= "Focusyn" });

        }
    }
}
