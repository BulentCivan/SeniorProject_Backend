using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Test> Tests { get;set;}

        //public DbSet<Question> Questions { get;set;}
        public DbSet<Paradigm> Paradigms { get;set;}
        public DbSet<Mood> Moods { get;set;}

        public DbSet<UserParadigm> UserParadigms { get;set;}

        public DbSet<UserMood> UserMoods { get;set;}
        public DbSet<UserTest> UserTests { get;set;}
        //public DbSet<TestQuestion> TestQuestions { get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            
            builder.Entity<UserParadigm>(y => y.HasKey(r => new {r.AppUserId, r.ParadigmId}));
            builder.Entity<UserParadigm>()
                .HasOne(t => t.AppUser)
                .WithMany(t => t.UserParadigms)
                .HasForeignKey(r => r.AppUserId);
            builder.Entity<UserParadigm>()
                .HasOne(t => t.Paradigm)
                .WithMany(t => t.UserParadigms)
                .HasForeignKey(r => r.ParadigmId);

            /*builder.Entity<TestQuestion>(b => b.HasKey(n => new {n.TestId, n.QuestionId}));
            builder.Entity<TestQuestion>()
                .HasOne(m => m.Test)
                .WithMany(m => m.TestQuestions)
                .HasForeignKey(n => n.TestId);
            builder.Entity<TestQuestion>()
                .HasOne(m => m.Question)
                .WithMany(m => m.TestQuestions)
                .HasForeignKey(n => n.QuestionId);*/

            builder.Entity<UserMood>(b => b.HasKey(n => new {n.AppUserId, n.MoodId}));
            builder.Entity<UserMood>()
                .HasOne(m => m.AppUser)
                .WithMany(m => m.UserMoods)
                .HasForeignKey(n => n.AppUserId);
            builder.Entity<UserMood>()
                .HasOne(m => m.Mood)
                .WithMany(m => m.UserMoods)
                .HasForeignKey(n => n.MoodId);

            builder.Entity<UserTest>(b => b.HasKey(n => new {n.AppUserId, n.TestId}));
            builder.Entity<UserTest>()
                .HasOne(m => m.AppUser)
                .WithMany(m => m.UserTests)
                .HasForeignKey(n => n.AppUserId);
            builder.Entity<UserTest>()
                .HasOne(m => m.Test)
                .WithMany(m => m.UserTests)
                .HasForeignKey(n => n.TestId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName= "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName= "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}