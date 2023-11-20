using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfiguration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = new Guid("6bb6c848-f57b-4e77-ae77-d8e95745469b"),
                FirstName = "Egor",
                LastName = "Bezmenov",
                Email = "eg0rka@gmail.com",
            },
            new User
            {
                Id = new Guid("3809b0ec-d9fb-4d77-b4ac-b68b61a9d92b"),
                FirstName = "Ramzes",
                LastName = "II",
                Email = "ramza@egypt.com",
            },
            new User
            {
                Id = new Guid("bead2185-f206-48b8-92d0-904f7ff0e953"),
                FirstName = "Ermolay",
                LastName = "Kabanov",
                Email = "kabannder@yahoo.com",
            },
            new User
            {
                Id = new Guid("060a369a-aa6f-4a3a-9bcc-ab7c53ae3051"),
                FirstName = "Barbara",
                LastName = "Grinder",
                Email = "barbara.grinder@outlook.com",
            });
    }
}
