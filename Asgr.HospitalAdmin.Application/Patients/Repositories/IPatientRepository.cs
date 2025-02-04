using Asgr.HospitalAdmin.Application.Patients.Filters;
using Asgr.HospitalAdmin.Domain.Patients.Entities;

namespace Asgr.HospitalAdmin.Application.Patients.Repositories;

public interface IPatientRepository
{
    Task<IList<Patient>> SearchAsync(PatientFilter filter, CancellationToken cancellationToken = default);
    Task<int> CountAsync(PatientFilter filter, CancellationToken cancellationToken = default);
    Task<Patient> AddAsync(Patient patient, CancellationToken cancellationToken = default);
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Patient patient, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
