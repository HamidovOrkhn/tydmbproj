using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Models;

namespace TCYDMWebServices.Data
{
    public partial class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<OnlineQuery> OnlineQueries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<WhatWeDo> WhatWeDos { get; set; }
        public DbSet<WhoWeAre> WhoWeAres { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<Langluage> Languages { get; set; }
        public DbSet<ServiceInfo> ServiceInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Countries)
                .WithMany(b => b.Users);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Regions)
                .WithMany(b => b.Users);

            
        }
    }
}
