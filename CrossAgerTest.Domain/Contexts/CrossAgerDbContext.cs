using CrossAgerTest.Domain.Models.DbEntities;
using CrossAgerTest.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrossAgerTest.Domain.Contexts;

public class CrossAgerDbContext(
    DbContextOptions<CrossAgerDbContext> contextOptions) : DbContext(contextOptions)
{
    public DbSet<Table> Tables { get; set; }
    public DbSet<ClientsGroup> ClientsGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>().ToTable("table");
        modelBuilder.Entity<Table>().HasKey(table => table.Id);
        modelBuilder.Entity<Table>().Property(table => table.Id).HasColumnName("id");
        modelBuilder.Entity<Table>().Property(table => table.Size).HasColumnName("size");
        modelBuilder.Entity<Table>().Property(table => table.EmptyChairs).HasColumnName("empty_chairs");
        modelBuilder.Entity<Table>().HasMany(table => table.ClientsGroups);
        
        modelBuilder.Entity<ClientsGroup>().ToTable("clients_group");
        modelBuilder.Entity<ClientsGroup>().HasKey(clientsGroup => clientsGroup.Id);
        modelBuilder.Entity<ClientsGroup>().Property(clientsGroup => clientsGroup.Id).HasColumnName("id");
        modelBuilder.Entity<ClientsGroup>().Property(clientsGroup => clientsGroup.TableId).HasColumnName("table_id");
        modelBuilder.Entity<ClientsGroup>().Property(clientsGroup => clientsGroup.Size).HasColumnName("size");
        modelBuilder.Entity<ClientsGroup>().Property(clientsGroup => clientsGroup.State).HasColumnName("state")
            .HasConversion(new EnumToStringConverter<ClientsGroupState>());
        modelBuilder.Entity<ClientsGroup>().Property(clientsGroup => clientsGroup.ArrivedAt).HasColumnName("arrived_at");
        modelBuilder.Entity<ClientsGroup>().HasOne(clientsGroup => clientsGroup.Table).WithMany(table => table.ClientsGroups)
            .HasForeignKey(clientsGroup => clientsGroup.TableId);
    }
}