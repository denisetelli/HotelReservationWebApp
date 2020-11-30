using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationClient> ReservationClients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasKey(_ => _.UserId);
            modelBuilder
                .Entity<User>()
                .HasOne(_ => _.Role)
                .WithMany(_ => _.Users);

            modelBuilder
                .Entity<Role>()
                .HasKey(_ => _.RoleId);
            modelBuilder
                .Entity<Role>()
                .Property(_ => _.Type)
                .HasColumnName("Type")
                .HasColumnType("NVARCHAR(100)");

            modelBuilder
                .Entity<Room>()
                .HasKey(_ => _.RoomId);
            modelBuilder.Entity<Room>()
                .HasOne(_ => _.Category)
                .WithMany(_ => _.Rooms);
            modelBuilder.Entity<Room>()
                .Property(_ => _.Code)
                .HasColumnName("Code")
                .HasColumnType("NVARCHAR(5)");

            modelBuilder
                .Entity<Category>()
                .HasKey(_ => _.CategoryId);
            modelBuilder
                .Entity<Client>()
                .HasKey(_ => _.ClientId);

            modelBuilder
                .Entity<Reservation>()
                .HasKey(_ => _.ReservationId);
            modelBuilder
                .Entity<Reservation>()
                .HasOne(_ => _.MainGuest)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<Reservation>()
                .HasOne(_ => _.ContactPerson)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<Reservation>()
                .HasOne(_ => _.RoomCategory)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<Reservation>()
                .HasOne(_ => _.Room)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder
                .Entity<ReservationClient>()
                .ToTable("ReservationClients")
                .HasKey(_ => new { _.ReservationId, _.ClientId });
            modelBuilder
                .Entity<ReservationClient>()
                .HasOne(_ => _.Reservation)
                .WithMany(_ => _.ReservationClients)
                .HasForeignKey(_ => _.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder
                .Entity<ReservationClient>()
                .HasOne(_ => _.Client)
                .WithMany(_ => _.ReservationClients)
                .HasForeignKey(_ => _.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


