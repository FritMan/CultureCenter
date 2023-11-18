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

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<TypesOfEvent> TypesOfEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source =C:\\Users\\User\\source\\repos\\CultureCenter\\CultureCenter\\DataBase\\CultureDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("TEXT (100)");
            entity.Property(e => e.EventDate).HasColumnType("TEXT (10)");

            entity.HasOne(d => d.Types).WithMany(p => p.Events)
                .HasForeignKey(d => d.TypesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TypesOfEvent>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("TEXT (35)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
