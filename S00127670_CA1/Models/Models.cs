using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S00127670_CA1.Models
{
    public class College
    {
        public string name { get; set; }
        public string addressOne { get; set; }
        public string addressTwo { get; set; }
        public string addressThree { get; set; }
        public int founded { get; set; }
        public int enrollment { get; set; }
        public virtual List<Location> locations { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public virtual List<College> colleges { get; set; }
    }

    public class CollegeDb : DbContext
    {
        public DbSet<College> college { get; set; }
        public DbSet<Location> location { get; set; }
        public CollegeDb() : base("CollegeDb") { }
    }

    public class CollegeDbInit : DropCreateDatabaseAlways<CollegeDb>
    {
        protected override void Seed(CollegeDb context)
        {
            var seedCollegeData = new List<College>()
            {
                new College(){name="IT Sligo", addressOne="Ash Lane", addressTwo="Ballinode", addressThree="Sligo", founded=1970, enrollment=6500, locations =
                    new List<Location>()
                    {
                        new Location(){lat=54.278000, lng=-8.460000}
                    }}
            };
            seedCollegeData.ForEach(c => context.college.Add(c));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}