namespace eTreatMD.Migrations.CMSMigrations
{
    using eTreatMD_Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eTreatMD_Model.eTreatMDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CMSMigrations";
        }

        protected override void Seed(eTreatMD_Model.eTreatMDContext context)
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
            List<Location> locations = new List<Location>()
            {
                new Location { locationID = 1, latitude = 49.1838817, longitude = -123.13364430000001, address = "Aberdeen"},
                new Location { locationID = 2, latitude = 49.1502871, longitude = -123.1253155, address = "8571 Garden City"},
                new Location { locationID = 3, latitude = 49.1388451, longitude = -123.14956039999998, address = "Steveston London"},
            };
            context.locationList.AddOrUpdate(s => s.locationID, locations.ToArray());

            List<DoctorList> doctors = new List<DoctorList>()
            {
                new DoctorList { locationID = 1, country = "Canada", rankingOrder = 2},
                new DoctorList { locationID = 2, country = "Canada", rankingOrder = 1}
            };
            context.doctorList.AddOrUpdate(s => s.locationID, doctors.ToArray());

            List<HospitalList> hospitals = new List<HospitalList>()
            {
                new HospitalList { locationID = 3, country = "Canada", rankingOrder = 1},
            };
            context.hospitalList.AddOrUpdate(s => s.locationID, hospitals.ToArray());
        }
    }
}
