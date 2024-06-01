using System.Runtime.Serialization;

namespace EF_CF_Hospital.Exceptions;

public class DateInvalidException : Exception
{
    public DateInvalidException()
    {
    }

    protected DateInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DateInvalidException(string? message) : base(message)
    {
    }

    public DateInvalidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}