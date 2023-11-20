using Data.Entities;
using Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Data;

public sealed class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;
    private readonly int _connectionTimeoutInSeconds = 30;

    public ApplicationDbContext(SqliteDbFileService sqliteDbFileService)
    {
        _connectionString = sqliteDbFileService.ConnectionString;
    }

    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            _connectionString,
            options =>
            {
                options.CommandTimeout(_connectionTimeoutInSeconds);
            });

#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new RoomConfiguration());
    }
}
