using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00127670_CA1.Models
{
    public enum SportsTeams
    {
        Football, Hurling, Soccer, Rugby, Swimming
    }

    public class College
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int founded { get; set; }
        public int enrollment { get; set; }
        public SportsTeams sportsTeams { get; set; }
        public List<Location> locations { get; set; }
    }

    public class Location
    {
        public int locationId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<College> colleges { get; set; }
    }

    public class CollegeDb : DbContext
    {
        public DbSet<College> college { get; set; }
        public DbSet<Location> location { get; set; }
        public CollegeDb() : base("CollegeDb") { this.Configuration.LazyLoadingEnabled = false; }
    }

    public class CollegeDbInit : DropCreateDatabaseAlways<CollegeDb>
    {
        protected override void Seed(CollegeDb context)
        {
            var seedCollegeData = new List<College>()
            {
                new College(){name="Institute of Technology Sligo", address="Ash Lane, Ballinode, Co. Sligo", founded=1970, enrollment=6500, sportsTeams=SportsTeams.Football, locations =
                    new List<Location>()
                    {
                        new Location(){lat=54.278000, lng=-8.460000}
                    }},
                new College(){name="National University of Ireland Galway", address="University Road, Galway", founded=1845, enrollment=17483, sportsTeams=SportsTeams.Hurling, locations =
                    new List<Location>()
                    {
                        new Location(){lat=53.278860, lng=-9.060561}
                    }},
                new College(){name="Galway-Mayo Institute of Technology", address="Dublin Road, Galway", founded=1972, enrollment=5000, sportsTeams=SportsTeams.Rugby, locations =
                    new List<Location>()
                    {
                        new Location(){lat=53.279428, lng=-9.010464}
                    }},
                new College(){name="University College Cork", address="Coláiste Na Hollscoile, Bóthar an Choláiste, Corcaigh", founded=1845, enrollment=18820, sportsTeams=SportsTeams.Soccer, locations =
                    new List<Location>()
                    {
                        new Location(){lat=51.894977, lng=-8.492860}
                    }},
                new College(){name="University of Limerick", address="Castletroy, Co. Limerick", founded=1972, enrollment=17000, sportsTeams=SportsTeams.Swimming, locations =
                    new List<Location>()
                    {
                        new Location(){lat=52.671524, lng=-8.574482}
                    }},
                new College(){name="Institute of Technology Carlow", address="Kilkenny Road, Carlow", founded=1970, enrollment=4000, sportsTeams=SportsTeams.Football, locations =
                    new List<Location>()
                    {
                        new Location(){lat=52.827298, lng=-6.936106}
                    }},
                new College(){name="University College Dublin", address="Belfield, Dublin 4", founded=1854, enrollment=30870, sportsTeams=SportsTeams.Soccer, locations =
                    new List<Location>()
                    {
                        new Location(){lat=53.307262, lng=-6.219077}
                    }},
                new College(){name="Dublin City University", address="Glasnevin, Dublin 9", founded=1975, enrollment=11126, sportsTeams=SportsTeams.Hurling, locations =
                    new List<Location>()
                    {
                        new Location(){lat=53.385255, lng=-6.257138}
                    }},
                new College(){name="Letterkenny Institute of Technology", address="Port Rd, Letterkenny, Co. Donegal", founded=1971, enrollment=3000, sportsTeams=SportsTeams.Football, locations =
                    new List<Location>()
                    {
                        new Location(){lat=54.952413, lng=-7.720889}
                    }},
                new College(){name="Maynooth University", address="Maynooth, Co. Kildare", founded=1997, enrollment=8095, sportsTeams=SportsTeams.Hurling, locations =
                    new List<Location>()
                    {
                        new Location(){lat=53.3807, lng=-6.594596}
                    }},
            };
            seedCollegeData.ForEach(c => context.college.Add(c));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}