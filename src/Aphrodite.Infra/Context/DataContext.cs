using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.UserContext.Entities;
using Aphrodite.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using File = Aphrodite.Domain.CoreContext.Entities.File;

namespace Aphrodite.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Creative> Creatives { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Creative>(new CreativeMap().Configure);
        modelBuilder.Entity<File>(new FileMap().Configure);
        modelBuilder.Entity<Comment>(new CommentMap().Configure);
        
        modelBuilder.Entity<Address>(new AddressMap().Configure);
        modelBuilder.Entity<Admin>(new AdminMap().Configure);
        modelBuilder.Entity<Customer>(new CustomerMap().Configure);
    }
}