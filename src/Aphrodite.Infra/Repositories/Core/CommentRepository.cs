using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.CoreContext.Repositories;
using Aphrodite.Domain.UserContext.Entities;
using Aphrodite.Infra.Context;

namespace Aphrodite.Infra.Repositories.Core;

public class CommentRepository : ICommentRepository
{
    private readonly DataContext _context;

    public CommentRepository(DataContext context)
    {
        _context = context;
    }
    
    public bool UserExists(Guid userId)
    {
        return _context.Admins.Any(a => a.Id == userId) || _context.Customers.Any(c => c.Id == userId);
    }

    public BaseUser? GetUserById(Guid userId)
    {
        var admin = _context.Admins.FirstOrDefault(a => a.Id == userId);
        if (admin != null) return admin;

        var customer = _context.Customers.FirstOrDefault(c => c.Id == userId);
        if (customer != null) return customer;

        return null;
    }

    public void Save(Comment comment)
    {
        _context.Set<Comment>().Add(comment);
        _context.SaveChanges();
    }
}