using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Asgr.HospitalAdmin.Application;
using Asgr.HospitalAdmin.Application.Patients.Repositories;
using Asgr.HospitalAdmin.Domain.Patients.Entities;
using Asgr.HospitalAdmin.Application.Patients.Filters;

namespace Asgr.HospitalAdmin.Persistence.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalAdminDbContext _context;

    public PatientRepository(HospitalAdminDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Patient>> SearchAsync(PatientFilter filter, CancellationToken cancellationToken = default)
    {
        return await GetFilterQuery(filter)
            .Skip(filter.Skip)
            .Take(filter.Take)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(PatientFilter filter, CancellationToken cancellationToken = default)
    {
        return await GetFilterQuery(filter).CountAsync(cancellationToken: cancellationToken);
    }

    public async Task<Patient> AddAsync(Patient patient, CancellationToken cancellationToken = default)
    {
        await _context.Patients.AddAsync(patient, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return patient;
    }

    public async Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Patients
            .Include(p => p.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken = default)
    {
        _context.Patients.Update(patient);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var patient = await _context.Patients.FindAsync(id, cancellationToken);
        if (patient != null)
        {
            _context.Patients.Remove(patient);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    private IQueryable<Patient> GetFilterQuery(PatientFilter filter)
    {
        var query = _context.Patients.Include(p => p.Name).AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.BirthDateHl7))
        {
            var match = Regex.Match(filter.BirthDateHl7, Constants.HL7_DATE_FORMAT);
            var operatorString = match.Groups[1].Value;
            var birthDate = DateTime.Parse(match.Groups[2].Value);
            birthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);

            query = operatorString switch
            {
                "lt" => query.Where(p => p.BirthDate < birthDate),
                "le" => query.Where(p => p.BirthDate <= birthDate),
                "gt" => query.Where(p => p.BirthDate > birthDate),
                "ge" => query.Where(p => p.BirthDate >= birthDate),
                "ne" => query.Where(p => p.BirthDate != birthDate),
                "sa" => query.Where(p => p.BirthDate > birthDate),
                "eb" => query.Where(p => p.BirthDate < birthDate),
                "ap" => query.Where(p => Math.Abs((p.BirthDate - birthDate).TotalDays) <= 5),
                _ => query.Where(p => p.BirthDate.Date == birthDate.Date)
            };
        }

        return query;
    }
}
