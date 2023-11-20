using Data;
using HotelBookingTest;
using HotelBookingTest.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

var builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile(
    path: "config.json",
    optional: false,
    reloadOnChange: false);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<SqliteDbFileService>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    {
        Console.WriteLine("Checking DB file...");

        var dbFileService = scope.ServiceProvider.GetService<SqliteDbFileService>()!;
        var sqliteFileLocation = dbFileService.DbFilePath;

        if (File.Exists(sqliteFileLocation))
        {
            Console.WriteLine("DB file exists");
        }
        else
        {
            string directoryPath = Path.GetDirectoryName(sqliteFileLocation)
                ?? throw new Exception("Unable to extract directory name from DB file path!");

            Directory.CreateDirectory(directoryPath);

            using var _ = File.Create(sqliteFileLocation);

            Console.WriteLine("DB file created");
        }
    }

    {
        Console.WriteLine("Checking migrations...");

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()
            ?? throw new Exception($"Unable to create instance of service: '{nameof(ApplicationDbContext)}'");

        context.Database.Migrate();

        Console.WriteLine("Migrations have been applied");
    }
}

Console.WriteLine("Initializing generator");

BookingGenerator generator;

using (var scope = host.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

    var roomIds = context.Rooms
        .Select(r => r.Id)
        .ToList();

    var userIds = context.Users
        .Select(u => u.Id)
        .ToList();

    generator = new BookingGenerator(roomIds, userIds);
}

SeedHelper.SeedData(
    host,
    generator,
    iterations: 400,
    bookingsPerIteration: 10 * 1000);

{
    const int SEARCHES_COUNT = 10;

    var timer = new Stopwatch();
    var totalElapsed = new TimeSpan();

    using var scope = host.Services.CreateScope();
    using var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

    var startTime = new DateTime(1641, 10, 27);
    var endTime = new DateTime(1750, 1, 1);

    var usersCount = context.Users
        .Count();

    var allUserIds = context.Users
        .Select(u => u.Id)
        .ToList();

    Console.WriteLine("Start searching benchmark");

    for (int i = 0; i < SEARCHES_COUNT; i++)
    {
        var randomGuid = Guid.NewGuid();

        Guid randomUserId = SEARCHES_COUNT <= usersCount
            ? allUserIds[i]
            : allUserIds[SEARCHES_COUNT % usersCount];

        Console.Write($"Try {i + 1} ");
        timer.Restart();

        int bookingsFound = context.Bookings
            .AsNoTracking()
            .Where(x => x.Start > startTime)
            .Where(x => x.End < endTime)
            .Where(x => x.UserId != randomUserId)
            .Count();

        timer.Stop();
        totalElapsed += timer.Elapsed;

        Console.WriteLine($"finished. Elapsed: {timer.Elapsed.TotalSeconds} s. {bookingsFound} bookings found.");

        startTime = startTime.AddHours(11);
        endTime = endTime.AddHours(11);
    }

    Console.WriteLine("Search benchmark ends.");
}