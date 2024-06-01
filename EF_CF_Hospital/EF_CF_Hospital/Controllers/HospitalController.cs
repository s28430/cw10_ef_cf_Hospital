using EF_CF_Hospital.Dtos.RequestDtos;
using EF_CF_Hospital.Exceptions;
using EF_CF_Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_CF_Hospital.Controllers;

[ApiController]
[Route("api/hospital")]
public class HospitalController(IPrescriptionService prescriptionService) : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService = prescriptionService;
    
    [HttpPost("/prescriptions/add")]
    public async Task<IActionResult> AddPrescription(AddPrescriptionRequestDto data,
        CancellationToken cancellationToken)
    {

        try
        {
            return StatusCode(201, await _prescriptionService.AddPrescriptionAsync(data, cancellationToken));
        }
        catch (Exception e) when (e is DoctorNotFoundException or MedicamentNotFoundException)
        {
            return NotFound(e.Message);
        }
        catch (DateInvalidException e)
        {
            return Conflict(e.Message);
        }
    }
}