using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Aphrodite.Domain.CoreContext.Entities.File;

namespace Aphrodite.Infra.Mapping;

public class FileMap
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.ToTable("files");
    }
}