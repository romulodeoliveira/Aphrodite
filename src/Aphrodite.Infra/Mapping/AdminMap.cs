using Aphrodite.Domain.UserContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aphrodite.Infra.Mapping;

public class AdminMap
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("admins");
    }
}