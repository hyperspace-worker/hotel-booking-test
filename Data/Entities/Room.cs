using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public sealed class Room
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
