﻿namespace DAL.Migrations
{
    using Bogus;
    using DAL.EF;
    using DAL.EF.Helper;
    using DAL.EF.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.DMTEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        protected override void Seed(DAL.EF.DMTEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            try
            {
                List<User> users = new List<User>();

                users.Add(new User()
                {
                    id = "Bishop",
                    name = "Al-monaem khan",
                    email = "shanto45777@gmail.com",
                    password = HashPassword.Hash("1234"),
                    dob = DateTime.Now.AddDays(-20),
                    phone = "01875609450",
                    role = 1,
                    wallet=100
                });
                users.Add(new User()
                {
                    id = "Abyss",
                    name = "Al-monaem khan",
                    email = "abyss@gmail.com",
                    password = HashPassword.Hash("1234"),
                    dob = DateTime.Now.AddDays(-20),
                    phone = "01875609450",
                    wallet = 100
                });
                users.Add(new User()
                {
                    id = "Alvin",
                    name = "Al-monaem khan",
                    email = "alvin@gmail.com",
                    password = HashPassword.Hash("1234"),
                    dob = DateTime.Now.AddDays(-20),
                    phone = "01875609450",
                    wallet = 100
                });
                users.Add(new User()
                {
                    id = "Sayeth",
                    name = "Al-monaem khan",
                    email = "sayeth@gmail.com",
                    password = HashPassword.Hash("1234"),
                    dob = DateTime.Now.AddDays(-20),
                    phone = "01875609450",
                    wallet = 100
                });
                users.Add(new User()
                {
                    id = "Shanto",
                    name = "Al-monaem khan",
                    email = "20-42650-1@student.aiub.edu",
                    password = HashPassword.Hash("1234"),
                    dob = DateTime.Now.AddDays(-20),
                    phone = "01875609450",
                    wallet = 100,
                    role =1
                });

                for (int i = 0; i < 200; i++)
                {
                    var faker = new Faker<User>()
                        .RuleFor(x => x.id, x => x.Person.UserName)
                        .RuleFor(x => x.email, x => x.Person.Email)
                        .RuleFor(x => x.password, x => HashPassword.Hash(Guid.NewGuid().ToString()))
                        .RuleFor(x => x.name, x => x.Person.FullName)
                        .RuleFor(x => x.phone, x => x.Person.Phone)
                        .RuleFor(x => x.registrationDate, x => GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1)));

                    var user = faker.Generate();
                    foreach(var u in users)
                    {
                        if (u.id.Equals(user.id) || u.email.Equals(user.email))
                        {
                            continue;
                        }
                    }

                    users.Add(user);
                }

                context.Users.AddOrUpdate(users.ToArray());
                //SaveChanges(context, users);


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
                stations.Add(new Station()
                {
                    id = "Kazipara",
                    latitude = 23.7970495,
                    longitude = 90.3729062
                });
                stations.Add(new Station()
                {
                    id = "Shewrapara",
                    latitude = 23.788592,
                    longitude = 90.376480
                });
                stations.Add(new Station()
                {
                    id = "Agargaon",
                    latitude = 23.781057,
                    longitude = 90.379320
                });
                stations.Add(new Station()
                {
                    id = "Farmgate",
                    latitude = 23.757174,
                    longitude = 23.757174
                });

                context.Stations.AddOrUpdate(stations.ToArray());

                List<Route> routes = new List<Route>();
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Mirpur-11",
                    price = 20
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Mirpur-12",
                    price = 30
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Kazipara",
                    price = 20
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Shewrapara",
                    price = 30
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Agargaon",
                    price = 40
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-10",
                    station_2 = "Farmgate",
                    price = 50
                });
                routes.Add(new Route()
                {
                    station_1 = "Mirpur-11",
                    station_2 = "Farmgate",
                    price = 60
                });

                context.Routes.AddOrUpdate(routes.ToArray());

                List<Ticket> tickets = new List<Ticket>();
                for (int i = 1; i < routes.Count; i++)
                {
                    tickets.Add(new Ticket()
                    {
                        route_id = i,
                    });
                }
                context.Tickets.AddOrUpdate(tickets.ToArray());

                List<Transaction> transactions = new List<Transaction>();
                transactions.Add(new Transaction()
                {
                    method = "wallet",
                    ticket_id = 1,
                    transaction_id = "trx-1f09348ahbjkbavu-wlt",
                    user_id = "Bishop",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                transactions.Add(new Transaction()
                {
                    method = "wallet",
                    ticket_id = 3,
                    transaction_id = "trx-1f09348ahbjkbavu-wlt",
                    user_id = "Bishop",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                transactions.Add(new Transaction()
                {
                    method = "ssl",
                    ticket_id = 4,
                    user_id = "Bishop",
                    transaction_id = "trx-1f09348ahbjkbavu-ssl",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                transactions.Add(new Transaction()
                {
                    method = "ssl",
                    ticket_id = 3,
                    transaction_id = "trx-1f09348ahbjkbavu-ssl",
                    user_id = "Bishop",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                transactions.Add(new Transaction()
                {
                    method = "wallet",
                    ticket_id = 5,
                    transaction_id = "trx-1f09348ahbjkbavu-wlt",
                    user_id = "Abyss",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                transactions.Add(new Transaction()
                {
                    method = "wallet",
                    ticket_id = 2,
                    transaction_id = "trx-1f09348ahbjkbavu-wlt",
                    user_id = "Abyss",
                    date = GetRandomDate(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1))
                });
                context.Transactions.AddOrUpdate(transactions.ToArray());

                List<Revenue> revenues = new List<Revenue>();
                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-1),
                    revenue_app = 2000,
                    revenue_manual = 1500,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });
                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-2),
                    revenue_app = 1100,
                    revenue_manual = 1400,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-3),
                    revenue_app = 2300,
                    revenue_manual = 2000,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-4),
                    revenue_app = 1200,
                    revenue_manual = 1500,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-5),
                    revenue_app = 1700,
                    revenue_manual = 1000,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-6),
                    revenue_app = 1600,
                    revenue_manual = 800,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-7),
                    revenue_app = 1100,
                    revenue_manual = 1900,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-8),
                    revenue_app = 1500,
                    revenue_manual = 1300,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                revenues.Add(new Revenue()
                {
                    date = DateTime.Today.AddDays(-9),
                    revenue_app = 1600,
                    revenue_manual = 1500,
                    tickets_sold_app = 100,
                    tickets_sold_manual = 100
                });

                context.Revenues.AddOrUpdate(revenues.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
