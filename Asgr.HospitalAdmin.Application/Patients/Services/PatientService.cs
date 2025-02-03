using Asgr.HospitalAdmin.Application.Patients.Dto;
using Asgr.HospitalAdmin.Application.Patients.Filters;
using Asgr.HospitalAdmin.Application.Patients.Mappers;
using Asgr.HospitalAdmin.Application.Patients.Repositories;
using Asgr.HospitalAdmin.Application.Patients.Services.Interfaces;

namespace Asgr.HospitalAdmin.Application.Patients.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IList<PatientDto>> SearchAsync(PatientFilter filter, CancellationToken cancellationToken = default)
    {
        var patients = await _patientRepository.SearchAsync(filter, cancellationToken);
        var result = patients.Select(x => x.ToDto()).ToArray();
        
        return result;
    }

    public Task<int> CountAsync(PatientFilter filter, CancellationToken cancellationToken = default)
    {
        var result = _patientRepository.CountAsync(filter, cancellationToken);
        
        return result;
    }

    public async Task<PatientDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty) return null;

        var patient = await _patientRepository.GetByIdAsync(id, cancellationToken);
        var result = patient.ToDto();

        return result;
    }

    public async Task CreateAsync(PatientDto patient, CancellationToken cancellationToken = default)
    {
        await _patientRepository.AddAsync(patient.ToEntity(), cancellationToken);
    }

    public async Task UpdateAsync(PatientDto patient, CancellationToken cancellationToken = default)
    {
        await _patientRepository.UpdateAsync(patient.ToEntity(), cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _patientRepository.DeleteAsync(id, cancellationToken);
    }
}

