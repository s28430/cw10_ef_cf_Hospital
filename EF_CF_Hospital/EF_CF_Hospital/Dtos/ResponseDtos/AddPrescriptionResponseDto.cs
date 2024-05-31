using System.ComponentModel.DataAnnotations;
using EF_CF_Hospital.Dtos.EntitiesDtos;

namespace EF_CF_Hospital.Dtos.ResponseDtos;

public class AddPrescriptionResponseDto
{
    [Required]
    public int IdPrescription { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public PatientDto PatientDto { get; set; } = null!;
    
    [Required]
    public DoctorDto DoctorDto { get; set; } = null!;
}