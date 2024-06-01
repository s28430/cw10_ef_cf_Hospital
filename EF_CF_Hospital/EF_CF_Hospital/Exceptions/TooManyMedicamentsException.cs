using System.Runtime.Serialization;

namespace EF_CF_Hospital.Exceptions;

public class TooManyMedicamentsException : Exception
{
    public TooManyMedicamentsException()
    {
    }

    protected TooManyMedicamentsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public TooManyMedicamentsException(string? message) : base(message)
    {
    }

    public TooManyMedicamentsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}