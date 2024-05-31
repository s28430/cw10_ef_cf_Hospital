using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_Hospital.Entities;

[PrimaryKey(nameof(IdPrescription), [nameof(IdMedicament)])]
public class PrescriptionMedicament
{
    public int IdPrescription { get; set; }
    
    public int IdMedicament { get; set; }

    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    
    public int? Dose { get; set; }

    [Required]
    [MaxLength(100)]
    public string Details { get; set; } = null!;
}