using System.Runtime.Serialization;

namespace EF_CF_Hospital.Exceptions;

public class MedicamentNotFoundException : Exception
{
    public MedicamentNotFoundException()
    {
    }

    protected MedicamentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MedicamentNotFoundException(string? message) : base(message)
    {
    }

    public MedicamentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}