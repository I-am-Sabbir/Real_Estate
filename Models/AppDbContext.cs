using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.user_name).IsUnique();
            modelBuilder.Entity<User>().HasKey(u => u.ID);
            modelBuilder.Entity<Buyer>().HasKey(u => u.userID);
            modelBuilder.Entity<Builder>().HasKey(u => u.UserID);
            modelBuilder.Entity<Buyer>()
                .HasOne<User>(u => u.User)
                .WithOne()
                .HasForeignKey<Buyer>(u => u.userID);
           
            modelBuilder.Entity<Builder>()
                .HasOne<User>(u => u.User)
                .WithOne()
                .HasForeignKey<Builder>(u => u.UserID);
           
            modelBuilder.Entity<Apartment>()
                .HasOne<Builder>(b => b.Builder)
                .WithMany(a => a.Apartments)
                .HasForeignKey(a => a.BuilderID);

          /*  modelBuilder.Entity<Report>()
                .HasOne<Apartment>(a => a.Apartment)
                .WithMany();

            modelBuilder.Entity<Report>()
                .HasOne<Buyer>(b => b.Buyer)
                .WithMany();

            modelBuilder.Entity<Requested>()
                .HasOne<Apartment>(a => a.Apartment)
                .WithMany();


            modelBuilder.Entity<Requested>()
                .HasOne<Buyer>(b => b.Buyer)
                .WithMany();*/
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Requested> Requesteds { get; set; }
    }
}
