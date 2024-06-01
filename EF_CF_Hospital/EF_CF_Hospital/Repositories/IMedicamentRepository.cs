using EF_CF_Hospital.Entities;

namespace EF_CF_Hospital.Repositories;

public interface IMedicamentRepository
{
    public Task<Medicament?> GetMedicamentByIdAsync(int id, CancellationToken cancellationToken);
}