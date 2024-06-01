using EF_CF_Hospital.Context;
using EF_CF_Hospital.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_Hospital.Repositories;

public class DoctorRepository(HospitalDbContext dbContext) : IDoctorRepository
{
    private readonly HospitalDbContext _dbContext = dbContext;
    
    public async Task<Doctor?> GetDoctorByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Doctors
            .Where(d => d.IdDoctor == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
}