using Aphrodite.Domain.CoreContext.Entities;
using Aphrodite.Domain.UserContext.Entities;

namespace Aphrodite.Domain.CoreContext.Repositories;

public interface ICommentRepository
{
    bool UserExists(Guid userId);
    BaseUser? GetUserById(Guid userId);
    void Save(Comment comment);
}