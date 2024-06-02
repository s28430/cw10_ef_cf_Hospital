using EF_CF_Hospital.Context;
using EF_CF_Hospital.Entities;

namespace EF_CF_Hospital.Repositories;

public class PrescriptionRepository(HospitalDbContext dbContext) : IPrescriptionRepository
{
    private readonly HospitalDbContext _dbContext = dbContext;
    
    public async Task<int> AddPrescriptionAsync(DateTime date, DateTime dueDate, int idPatient, int idDoctor, 
        CancellationToken cancellationToken)
    {
        var prescription = new Prescription
        {
            Date = date,
            DueDate = dueDate,
            IdDoctor = idDoctor,
            IdPatient = idPatient
        };

        await _dbContext.Prescriptions.AddAsync(prescription, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return prescription.IdPrescription;
    }

    public async Task<PrescriptionMedicament> AssociatePrescriptionWithMedicamentAsync(int idPrescription, int idMedicament, 
        int? dose, string details, CancellationToken cancellationToken)
    {
        var pm = new PrescriptionMedicament
        {
            IdPrescription = idPrescription,
            IdMedicament = idMedicament,
            Dose = dose,
            Details = details
        };
        await _dbContext.PrescriptionMedicaments.AddAsync(pm, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return pm;
    }
}