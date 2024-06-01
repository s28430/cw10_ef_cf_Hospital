using EF_CF_Hospital.Entities;

namespace EF_CF_Hospital.Repositories;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescriptionAsync(DateTime date, DateTime dueDate,
        int idPatient, int idDoctor, CancellationToken cancellationToken);

    public Task<PrescriptionMedicament> AssociatePrescriptionWithMedicamentAsync(int idPrescription, int idMedicament,
        int? dose, string details, CancellationToken cancellationToken);
}