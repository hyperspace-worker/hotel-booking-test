using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public sealed class User
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
