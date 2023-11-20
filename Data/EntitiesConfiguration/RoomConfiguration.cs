using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfiguration;

internal sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasData(
            new Room
            {
                Id = new Guid("a5a2b423-e5af-42cc-8853-473f78843b00"),
                Name = "Hotel 512",
                Description = "You will be satisfied at 5 stars!",
            },
            new Room
            {
                Id = new Guid("ee9a26df-5a6e-4c44-be63-79adb3477aa4"),
                Name = "Small Room From Baba Yaga",
                Description = "Someone will roll on your bones...",
            },
            new Room
            {
                Id = new Guid("bd9c033c-6829-4afd-a186-584ab3599284"),
                Name = "Hotel ***",
                Description = "Just simple hotel, nothing to say",
            },
            new Room
            {
                Id = new Guid("959ccd09-7787-475f-9e9c-1c50432bff18"),
                Name = "Your mom's Room",
                Description = "Oh my god, so sweet (^-^)",
            });
    }
}
