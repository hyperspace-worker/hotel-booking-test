using Bogus;
using Data.Entities;

namespace HotelBookingTest;

public sealed class BookingGenerator
{
    private static DateTime _bookingStartTime = new(1400, 1, 1);

    private static readonly List<string> _bookingTitles =
    [
        "simple booking",
        "the shooking",
        "book reverse",
        "faraon attraction",
        "v gorle pershit",
        "mr proper vse otmil i parket ne povredil",
        "gazoviy raion",
        "dumpel shumpel",
        "lisiy shufel",
        "kaban baraban",
    ];

    private readonly IEnumerable<Guid> _roomIds;
    private readonly IEnumerable<Guid> _userIds;
    private readonly Faker<Booking> _bookingFaker;

    public BookingGenerator(IEnumerable<Guid> roomIds, IEnumerable<Guid> userIds)
    {
        _roomIds = roomIds;
        _userIds = userIds;

        _bookingFaker = new Faker<Booking>()
            .RuleFor(b => b.Id, f => Guid.NewGuid())
            .RuleFor(b => b.RoomId, f => f.PickRandom(roomIds))
            .RuleFor(b => b.UserId, f => f.PickRandom(userIds))
            .RuleFor(b => b.Title, f => f.PickRandom(_bookingTitles))
            .RuleFor(
                b => b.Start,
                f =>
                {
                    int yearsToAdd = f.Random.Number(0, 5000);
                    int monthsToAdd = f.Random.Number(0, 11);
                    int daysToAdd = f.Random.Number(0, 30);
                    int hoursToAdd = f.Random.Number(1, 10);

                    var startTime = _bookingStartTime
                        .AddYears(yearsToAdd)
                        .AddMonths(monthsToAdd)
                        .AddDays(daysToAdd)
                        .AddHours(hoursToAdd);

                    return startTime;
                })
            .RuleFor(b => b.End, (f, b) =>
            {
                var bookingLengthInHours = f.Random.Number(12, 60);

                return b.Start.AddHours(bookingLengthInHours);
            });
    }

    public List<Booking> GenerateBookings(int count)
    {
        var bookings = new List<Booking>(count);

        for (int i = 0; i < count; i++)
        {
            bookings.Add(_bookingFaker.Generate());
        }

        return bookings;
    }
}
