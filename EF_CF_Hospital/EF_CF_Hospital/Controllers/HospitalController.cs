using EF_CF_Hospital.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace EF_CF_Hospital.Controllers;

[ApiController]
[Route("api/hospital")]
public class HospitalController : ControllerBase
{
    [HttpPost("/prescriptions/add")]
    public async Task<IActionResult> AddPrescription(AddPrescriptionRequestDto data)
    {
        return Ok();
    }
}