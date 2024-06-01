using System.ComponentModel.DataAnnotations;

namespace EF_CF_Hospital.Dtos.EntitiesDtos;

public class MedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = null!;
}