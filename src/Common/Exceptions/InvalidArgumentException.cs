namespace Common.Exceptions;

public class InvalidArgumentException : BaseException
{
    public InvalidArgumentException(string message) : base(message)
    {
    }
}