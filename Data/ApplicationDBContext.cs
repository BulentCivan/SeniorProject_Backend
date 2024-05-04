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
        public DbSet<Result> Results { get;set;}
        public DbSet<Question> Questions { get;set;}
        public DbSet<Paradigm> Paradigms { get;set;}
        public DbSet<Profile> Profiles { get;set;}
        public DbSet<UserParadigm> UserParadigms { get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Profile>(x => x.HasKey(p => new {p.AppUserId, p.ResultId}));
            builder.Entity<Profile>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Profiles)
                .HasForeignKey(p => p.AppUserId);
            builder.Entity<Profile>()
                .HasOne(u => u.Result)
                .WithMany(u => u.Profiles)
                .HasForeignKey(p => p.ResultId);

            builder.Entity<UserParadigm>(y => y.HasKey(r => new {r.AppUserId, r.ParadigmId}));
            builder.Entity<UserParadigm>()
                .HasOne(t => t.AppUser)
                .WithMany(t => t.UserParadigms)
                .HasForeignKey(t => t.AppUserId);
            builder.Entity<UserParadigm>()
                .HasOne(t => t.Paradigm)
                .WithMany(t => t.UserParadigms)
                .HasForeignKey(p => p.ParadigmId);

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