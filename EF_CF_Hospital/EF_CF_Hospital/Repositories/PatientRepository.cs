using EF_CF_Hospital.Context;
using EF_CF_Hospital.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_Hospital.Repositories;

public class PatientRepository(HospitalDbContext dbContext) : IPatientRepository
{
    private readonly HospitalDbContext _dbContext = dbContext;
    
    public async Task<Patient?> GetPatientByIdAndFullNameAsync(int idPatient, string firstName,
        string lastName, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Patients
            .Where(p => p.IdPatient == idPatient && p.FirstName == firstName && p.LastName == lastName)
            .SingleAsync(cancellationToken);
    }

    public async Task<int> AddPatientAsync(string firstName, string lastName, DateTime birthDate,
        CancellationToken cancellationToken)
    {
        var newPatient = new Patient
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate,
            Prescriptions = new List<Prescription>()
        };
        _dbContext.Patients.Attach(newPatient);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newPatient.IdPatient;
    }
}