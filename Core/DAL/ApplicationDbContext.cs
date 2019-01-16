using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    internal class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(): base("DefaultConnection")
        { }

        //DbSets
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Donations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.OwnedOffers)
                .WithOptional(e => e.Owner)
                .HasForeignKey(e => e.OwnerId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Files)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Ratings)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Offer>()
                .HasMany(e => e.Participants)
                .WithMany(e => e.Participating)
                .Map(m => m.ToTable("Participants").MapLeftKey("OfferId").MapRightKey("UserId"));
        }
    }
    }

