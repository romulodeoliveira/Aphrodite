using Aphrodite.Domain.CoreContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aphrodite.Infra.Mapping;

public class CreativeMap
{
    public void Configure(EntityTypeBuilder<Creative> builder)
    {
        builder.ToTable("creatives");
    }
}