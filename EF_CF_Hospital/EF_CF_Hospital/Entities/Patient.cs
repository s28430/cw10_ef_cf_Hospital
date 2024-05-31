using System.ComponentModel.DataAnnotations;

namespace EF_CF_Hospital.Entities;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = null!;
}