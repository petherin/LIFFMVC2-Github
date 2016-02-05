namespace LIFFMVC2.DataContexts.FilmMigrations
{
    using LIFFMVC2.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LIFFMVC2.DataContexts.FilmsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\FilmMigrations";
        }

        //enable-migrations -ContextTypeName FilmsDb DataContexts\FilmMigrations
        //enable-migrations -ContextTypeName IdentityDb DataContexts\IdentityMigrations
        //add-migration -ConfigurationTypeName LIFFMVC2.DataContexts.FilmMigrations.Configuration "RunningTimeSubtitles"
        //update-database -ConfigurationTypeName LIFFMVC2.DataContexts.FilmMigrations.Configuration  -  runs all migrations to latest version
        //update-database -ConfigurationTypeName LIFFMVC2.DataContexts.FilmMigrations.Configuration -TargetMigration:$InitialDatabase  -  blitzes the tables
        
            //http://www.itorian.com/2013/10/area-in-mvc-5-with-example-step-by-step.html - creating an admin and non-admin area

        protected override void Seed(LIFFMVC2.DataContexts.FilmsDb context)
        {
            Collection<Country> UKList = new Collection<Country>() { new Country { Name = "UK" } };
            Collection<Country> USAList = new Collection<Country>() { new Country { Name = "USA" } };
            
            Venue TownHallVictoriaHall = new Venue { Name = "Victoria Hall" };
            Venue VueTheLight = new Venue { Name = "Vue The Light" };

            Collection<Director> KubrickList = new Collection<Director> { new Director { Name = "Stanley Kubrick" } };
            Collection<Director> LucasList = new Collection<Director> { new Director { Name = "George Lucas" } };

            Film SpaceOdyssey = new Film
            {
                Title = "2001: a Space Odyssey",
                Country = UKList,
                Description = "Epic science fiction.",
                Director = KubrickList,
                Year = 1968,
                TrailerURL = "https://www.youtube.com/watch?v=lfF0vxKZRhc",
                RunningTime = 121,
                Subtitles = false,
                Images = new Collection<ImagePath>
                {
                    new ImagePath { Path = "~/Content/Images/1349282020_2001_7.jpg" },
                    new ImagePath { Path = "~/Content/Images/2001-2.jpg" },
                    new ImagePath { Path = "~/Content/Images/2001-3.jpg" }
                }
            };
            Film StarWars = new Film
            {
                Title = "Star Wars Episode IV: A New Hope",
                Country = USAList,
                Description = "Epic space opera.",
                Director = LucasList,
                Year = 1977,
                TrailerURL = "https://www.youtube.com/watch?v=1g3_CFmnU7k",
                RunningTime = 116,
                Subtitles = false,
                Images = new Collection<ImagePath>
                {
                    new ImagePath { Path = "~/Content/Images/Star_wars_old.jpg" },
                    new ImagePath { Path = "~/Content/Images/StarWars2.jpg" },
                    new ImagePath { Path = "~/Content/Images/StarWars3.jpg" }
                }
            };

            TimeSlot slot1 = new TimeSlot
            {
                Film = SpaceOdyssey,
                Venue = TownHallVictoriaHall,
                StartTime = new DateTime(2015, 11, 5, 20, 30, 00),
                EndTime = new DateTime(2015, 11, 5, 23, 00, 00)
            };
            TimeSlot slot2 = new TimeSlot
            {
                Film = StarWars,
                Venue = VueTheLight,
                StartTime = new DateTime(2015, 11, 6, 17, 00, 00),
                EndTime = new DateTime(2015, 11, 6, 19, 30, 00)
            };

            context.Slots.AddOrUpdate(s => s.Id, slot1, slot2);
            context.SaveChanges();
        }
    }
}
