using EF_CF_Hospital.Dtos.EntitiesDtos;
using EF_CF_Hospital.Dtos.RequestDtos;
using EF_CF_Hospital.Dtos.ResponseDtos;
using EF_CF_Hospital.Repositories;

namespace EF_CF_Hospital.Services;

public class PrescriptionService(IPatientRepository patientRepository) : IPrescriptionService
{
    private readonly IPatientRepository _patientRepository = patientRepository;


    private async Task EnsurePatientExistsAsync(PatientDto patientDto, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetPatientByIdAndFullNameAsync(
            patientDto.IdPatient, patientDto.FirstName, patientDto.LastName, cancellationToken);

        if (patient is null)
        {
            _ = await _patientRepository.AddPatientAsync(patientDto.FirstName, patientDto.LastName,
                patientDto.BirthDate, cancellationToken);
        }
    }
    
    public async Task<AddPrescriptionResponseDto> AddPrescriptionAsync(AddPrescriptionRequestDto data,
        CancellationToken cancellationToken)
    {
        await EnsurePatientExistsAsync(data.PatientDto, cancellationToken);
        return null;
    }
}