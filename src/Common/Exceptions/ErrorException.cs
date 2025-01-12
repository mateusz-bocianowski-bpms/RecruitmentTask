namespace Common.Exceptions;

public class ErrorException : BaseException
{
    public ErrorException(string message) : base(message)
    {
    }
}