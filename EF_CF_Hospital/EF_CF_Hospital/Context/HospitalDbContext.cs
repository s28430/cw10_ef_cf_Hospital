using EF_CF_Hospital.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_Hospital.Context;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {}

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) 
        : base(options)
    {}

    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }

    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}