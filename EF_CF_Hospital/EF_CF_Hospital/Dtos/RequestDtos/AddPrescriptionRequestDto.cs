using System.ComponentModel.DataAnnotations;
using EF_CF_Hospital.Dtos.EntitiesDtos;

namespace EF_CF_Hospital.Dtos.RequestDtos;

public class AddPrescriptionRequestDto
{
    [Required] 
    public PatientDto PatientDto { get; set; } = null!;

    [Required]
    public ICollection<MedicamentDto> MedicamentDtos { get; set; } = null!;

    [Required]
    public string Date { get; set; } = null!;
    
    [Required]
    public string DueDate { get; set; } = null!;
}