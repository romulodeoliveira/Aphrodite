using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.CoreContext.Repositories;
using Aphrodite.Infra.Context;

namespace Aphrodite.Infra.Repositories.Core;

public class CreativeRepository : ICreativeRepository
{
    private readonly DataContext _context;

    CreativeRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Save(Creative creative)
    {
        _context.Set<Creative>().Add(creative);
        _context.SaveChanges();
    }
}