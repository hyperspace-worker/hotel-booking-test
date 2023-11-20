using Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelBookingTest.Helpers;

public static class SeedHelper
{
    public static void SeedData(IHost host, BookingGenerator generator, int iterations = 1, int bookingsPerIteration = 1000)
    {
        int totalBookingsToAdd = iterations * bookingsPerIteration;
        int bookingsAdded = 0;

        Console.WriteLine("Start seeding...");

        for (int i = 0; i < iterations; i++)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

            context.Bookings.AddRange(
                generator.GenerateBookings(bookingsPerIteration));

            context.SaveChanges();

            bookingsAdded += bookingsPerIteration;
            float progress = bookingsAdded * 100f / totalBookingsToAdd;

            Console.WriteLine(
                string.Format("{0} bookins added! Progress: {1:f2}%", bookingsPerIteration, progress));
        }

        Console.WriteLine("Seeding finished!");
    }
}
