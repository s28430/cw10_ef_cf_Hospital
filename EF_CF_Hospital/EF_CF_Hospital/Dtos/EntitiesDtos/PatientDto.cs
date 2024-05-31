using System.ComponentModel.DataAnnotations;

namespace EF_CF_Hospital.Dtos.EntitiesDtos;

public class PatientDto
{
    [Required]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
}