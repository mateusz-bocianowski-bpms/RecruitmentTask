using Common.Exceptions;

namespace Common.Domain;

public class EntityNotFoundException : BaseException
{
    public EntityNotFoundException(string message) : base(message)
    {
    }
}