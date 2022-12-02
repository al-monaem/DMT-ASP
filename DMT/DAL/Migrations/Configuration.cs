namespace DAL.Migrations
{
    using DAL.EF.Helper;
    using DAL.EF.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.DMTEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.DMTEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //List<User> users = new List<User>();
            User user = new User()
            {
                id = "Bishop",
                name = "Al-monaem khan",
                email = "shanto45777@gmail.com",
                password = HashPassword.Hash("1234"),
                dob = DateTime.Now.AddDays(-20),
                phone = "01875609450"
            } ;
            context.Users.AddOrUpdate(user);

            List<Station> stations = new List<Station>();
            stations.Add(new Station()
            {
                id = "Mirpur-10",
                latitude = 23.8073343,
                longitude = 90.3688909
            });
            stations.Add(new Station()
            {
                id = "Mirpur-11",
                latitude = 23.8198167,
                longitude = 90.3646337
            });
            stations.Add(new Station()
            {
                id = "Mirpur-12",
                latitude = 23.825528,
                longitude = 90.364117
            });

            context.Stations.AddOrUpdate(stations.ToArray());
        }
    }
}
