using EF_CF_Hospital.Entities;

namespace EF_CF_Hospital.Repositories;

public interface IDoctorRepository
{
    public Task<Doctor?> GetDoctorByIdAsync(int id, CancellationToken cancellationToken);
}