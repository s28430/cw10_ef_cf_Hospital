using EF_CF_Hospital.Dtos.EntitiesDtos;
using EF_CF_Hospital.Dtos.RequestDtos;
using EF_CF_Hospital.Dtos.ResponseDtos;
using EF_CF_Hospital.Entities;
using EF_CF_Hospital.Exceptions;
using EF_CF_Hospital.Repositories;

namespace EF_CF_Hospital.Services;

public class PrescriptionService(IPatientRepository patientRepository, IMedicamentRepository medicamentRepository, 
    IDoctorRepository doctorRepository, IPrescriptionRepository prescriptionRepository) 
    : IPrescriptionService
{
    private readonly IPatientRepository _patientRepository = patientRepository;
    private readonly IMedicamentRepository _medicamentRepository = medicamentRepository;
    private readonly IDoctorRepository _doctorRepository = doctorRepository;
    private readonly IPrescriptionRepository _prescriptionRepository = prescriptionRepository;


    private async Task<Patient> EnsurePatientExistsAsync(PatientDto patientDto, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetPatientByIdAndFullNameAsync(
            patientDto.IdPatient, patientDto.FirstName, patientDto.LastName, cancellationToken);

        if (patient is null)
        {
            patient = await _patientRepository.AddPatientAsync(patientDto.FirstName, patientDto.LastName,
                patientDto.BirthDate, cancellationToken);
        }

        return patient;
    }

    private async Task<ICollection<Medicament>> GetMedicamentsAsync(ICollection<MedicamentDto> dtos,
        CancellationToken cancellationToken)
    {
        List<Medicament> result = [];
        foreach(var dto in dtos)
        {
            var medicament =
                await _medicamentRepository.GetMedicamentByIdAsync(dto.IdMedicament, cancellationToken);

            if (medicament is null)
            {
                throw new MedicamentNotFoundException($"Medicament with id {dto.IdMedicament} does not exist.");
            }
            result.Add(medicament);
        }

        return result;
    }

    private async Task<Doctor> GetDoctorByIdAsync(int id, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id, cancellationToken);
        if (doctor is null)
        {
            throw new DoctorNotFoundException($"Doctor with id {id} does not exist.");
        }

        return doctor;
    }

    private static void EnsureDatesAreValid(AddPrescriptionRequestDto data)
    {
        DateTime date;
        DateTime dueDate;
        try
        {
            date = DateTime.Parse(data.Date);
            dueDate = DateTime.Parse(data.DueDate);
        }
        catch (FormatException)
        {
            throw new DateInvalidException("The passed dates are invalid.");
        }
      
        if (dueDate < date)
        {
            throw new DateInvalidException($"Due date must be later than the date of prescribing.");
        }
    }
    
    public async Task<AddPrescriptionResponseDto> AddPrescriptionAsync(AddPrescriptionRequestDto data,
        CancellationToken cancellationToken)
    {
        var patient = await EnsurePatientExistsAsync(data.PatientDto, cancellationToken);
        var medicaments = await GetMedicamentsAsync(data.MedicamentDtos, cancellationToken);

        if (medicaments.Count > 10)
        {
            throw new TooManyMedicamentsException("Prescriptions cannot have more than 10 medicaments.");
        }
        
        var doctor = await GetDoctorByIdAsync(data.DoctorDto.IdDoctor, cancellationToken);
        EnsureDatesAreValid(data);

        var prescriptionId = await _prescriptionRepository.AddPrescriptionAsync(DateTime.Parse(data.Date), 
            DateTime.Parse(data.DueDate), patient.IdPatient, doctor.IdDoctor, cancellationToken);

        foreach (var medicament in data.MedicamentDtos)
        {
            await _prescriptionRepository.AssociatePrescriptionWithMedicamentAsync(prescriptionId,
                medicament.IdMedicament, medicament.Dose, medicament.Description, cancellationToken);
        }

        var response = new AddPrescriptionResponseDto
        {
            Date = DateTime.Parse(data.Date),
            DueDate = DateTime.Parse(data.DueDate),
            IdPrescription = prescriptionId,
            PatientDto = data.PatientDto,
            DoctorDto = data.DoctorDto
        };
        
        return response;
    }
}