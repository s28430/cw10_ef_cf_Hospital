using EF_CF_Hospital.Dtos.RequestDtos;
using EF_CF_Hospital.Dtos.ResponseDtos;

namespace EF_CF_Hospital.Services;

public interface IPrescriptionService
{
    public Task<AddPrescriptionResponseDto> AddPrescriptionAsync(AddPrescriptionRequestDto data,
        CancellationToken cancellationToken);
}