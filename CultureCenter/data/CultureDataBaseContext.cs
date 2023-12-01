using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CultureCenter.data;

public partial class CultureDataBaseContext : DbContext
{
    public CultureDataBaseContext()
    {
    }

    public CultureDataBaseContext(DbContextOptions<CultureDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TypesOfEvent> TypesOfEvents { get; set; }

    public virtual DbSet<WorkOrder> WorkOrders { get; set; }

    public virtual DbSet<WorkType> WorkTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source =.\\DataBase\\CultureDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.HasOne(d => d.Events).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("TEXT (100)");
            entity.Property(e => e.EventDate).HasColumnType("TEXT (10)");

            entity.HasOne(d => d.Types).WithMany(p => p.Events)
                .HasForeignKey(d => d.TypesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");
        });

        modelBuilder.Entity<TypesOfEvent>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("TEXT (35)");
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.ToTable("WorkOrder");

            entity.Property(e => e.DateEnd).HasColumnType("TEXT (10)");
            entity.Property(e => e.DateStart).HasColumnType("TEXT (10)");
            entity.Property(e => e.Description).HasColumnType("TEXT (100)");

            entity.HasOne(d => d.Events).WithMany(p => p.WorkOrders)
                .HasForeignKey(d => d.EventsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Room).WithMany(p => p.WorkOrders)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.WorkOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.WorkTypes).WithMany(p => p.WorkOrders)
                .HasForeignKey(d => d.WorkTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
