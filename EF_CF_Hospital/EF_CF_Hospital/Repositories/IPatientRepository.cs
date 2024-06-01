using EF_CF_Hospital.Entities;

namespace EF_CF_Hospital.Repositories;

public interface IPatientRepository
{
    public Task<Patient?> GetPatientByIdAndFullNameAsync(int idPatient, string firstName,
        string lastName, CancellationToken cancellationToken);

    public Task<Patient> AddPatientAsync(string firsName, string lastName, DateTime birthDate,
        CancellationToken cancellationToken);
}