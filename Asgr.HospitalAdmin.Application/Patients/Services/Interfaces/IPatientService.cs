using Asgr.HospitalAdmin.Application.Patients.Dto;
using Asgr.HospitalAdmin.Application.Patients.Filters;

namespace Asgr.HospitalAdmin.Application.Patients.Services.Interfaces;

public interface IPatientService
{
    Task<IList<PatientDto>> SearchAsync(PatientFilter filter, CancellationToken cancellationToken = default);
    Task<int> CountAsync(PatientFilter filter, CancellationToken cancellationToken = default);
    Task<PatientDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(PatientDto patient, CancellationToken cancellationToken = default);
    Task UpdateAsync(PatientDto patient, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}