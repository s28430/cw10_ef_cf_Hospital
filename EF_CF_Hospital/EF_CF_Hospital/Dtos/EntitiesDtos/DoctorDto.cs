using System.ComponentModel.DataAnnotations;

namespace EF_CF_Hospital.Dtos.EntitiesDtos;

public class DoctorDto
{
    [Required]
    public int IdDoctor { get; set; }

    [Required] 
    public string LastName { get; set; } = null!;
}