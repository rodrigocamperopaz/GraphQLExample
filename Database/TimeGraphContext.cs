﻿using GraphQLExample.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQLExample.Database
{
    public class TimeGraphContext : DbContext
    {
        public TimeGraphContext(DbContextOptions<TimeGraphContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project
            {
                CreatedBy = "Rodrigo",
                Id = 1,
                Name = "Nostromo"
            }, new Project
            {
                CreatedBy = "Rodrigo",
                Id = 2,
                Name = "Land on LV-426"
            });

            modelBuilder.Entity<TimeLog>().HasData(new TimeLog
            {
                Id = 1,
                From = new DateTime(2021, 7, 24, 12, 0, 0),
                To = new DateTime(2021, 7, 24, 14, 0, 0),
                ProjectId = 1,
                User = "Rodrigo"
            }, new TimeLog
            {
                Id = 2,
                From = new DateTime(2021, 7, 24, 16, 0, 0),
                To = new DateTime(2021, 7, 24, 18, 0, 0),
                ProjectId = 1,
                User = "Rodrigo"
            }, new TimeLog
            {
                Id = 3,
                From = new DateTime(2021, 7, 24, 20, 0, 0),
                To = new DateTime(2021, 7, 24, 22, 0, 0),
                ProjectId = 2,
                User = "Rodrigo"
            });
        }
    }
}
