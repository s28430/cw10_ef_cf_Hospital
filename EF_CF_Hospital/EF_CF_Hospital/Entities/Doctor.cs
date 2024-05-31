using System.ComponentModel.DataAnnotations;

namespace EF_CF_Hospital.Entities;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; } = null!;
}