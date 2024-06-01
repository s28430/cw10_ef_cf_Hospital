using EF_CF_Hospital.Context;
using EF_CF_Hospital.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_Hospital.Repositories;

public class MedicamentRepository(HospitalDbContext dbContext) : IMedicamentRepository
{
    private readonly HospitalDbContext _dbContext = dbContext;
    
    public async Task<Medicament?> GetMedicamentByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Medicaments
            .Where(m => m.IdMedicament == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
}