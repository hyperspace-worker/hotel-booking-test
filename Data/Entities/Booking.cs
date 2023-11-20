using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public sealed class Booking
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Title { get; set; } = string.Empty;

    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }
}
