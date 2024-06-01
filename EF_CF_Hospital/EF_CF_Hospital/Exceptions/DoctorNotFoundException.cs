using System.Runtime.Serialization;

namespace EF_CF_Hospital.Exceptions;

public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException()
    {
    }

    protected DoctorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DoctorNotFoundException(string? message) : base(message)
    {
    }

    public DoctorNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}