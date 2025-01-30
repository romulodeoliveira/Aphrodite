using Microsoft.EntityFrameworkCore;

namespace Aphrodite.Infra.Context;

public class DataContextFactory
{
    public static string DbConfig { get; } = "Server=localhost;Port=3306;Database=Aphrodite;Uid=root;Pwd=CSharp@123;";

    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseMySql(DbConfig, ServerVersion.AutoDetect(DbConfig));
        return new DataContext(optionsBuilder.Options);
    }
}