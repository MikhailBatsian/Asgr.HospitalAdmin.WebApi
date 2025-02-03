using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Asgr.HospitalAdmin.Application.Patients.Dto;
using Asgr.HospitalAdmin.Application.Patients.Filters;
using Asgr.HospitalAdmin.Application.Patients.Services.Interfaces;
using Asgr.HospitalAdmin.WebApi.Models.Request;
using Asgr.HospitalAdmin.WebApi.Models.Request.Mappers;
using Asgr.HospitalAdmin.WebApi.Models.Response;

namespace Asgr.HospitalAdmin.WebApi.Controllers;

[Route("api/patient")]
public class PatientController : Controller
{
    private const string PATIENT_EXISTS_MESSAGE = "Patient with {0} {1} already exists";
    private const string PATIENT_NOT_EXISTS_MESSAGE = "Patient with {0} {1} does not exist";

    private readonly IPatientService _patientService;
    private readonly IValidator<PatientRequestModel> _patientValidator;

    public PatientController(
        IPatientService patientService, 
        IValidator<PatientRequestModel> patientValidator)
    {
        _patientService = patientService;
        _patientValidator = patientValidator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] PatientFilterRequestModel filter, CancellationToken cancellationToken)
    {
        var patientFilter = new PatientFilter
        {
            Skip = filter.Skip,
            Take = filter.Take,
            BirthdayHl7 = filter.Birthday
        };

        var patients = await _patientService.SearchAsync(patientFilter, cancellationToken);
        var patientsCount = await _patientService.CountAsync(patientFilter, cancellationToken);
        
        return Ok(new PagingResponseModel<PatientDto>
        {
            TotalCount = patientsCount,
            Items = patients
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var patient = await _patientService.GetByIdAsync(id, cancellationToken);
        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PatientRequestModel requestModel, CancellationToken cancellationToken)
    {
        var validationResult = await _patientValidator.ValidateAsync(requestModel, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToDictionary());

        var existingPatient = await _patientService.GetByIdAsync(requestModel.Name.Id, cancellationToken);
        if (existingPatient != null)
        {
            ModelState.AddModelError(nameof(HumanNameRequestModel.Id), string.Format(PATIENT_EXISTS_MESSAGE, nameof(HumanNameRequestModel.Id), requestModel.Name.Id));
            return BadRequest(ModelState);
        }

        var patientDto = requestModel.ToDto();
       
        await _patientService.CreateAsync(patientDto, cancellationToken);

        return CreatedAtAction(nameof(Create), new { id = patientDto.Name.Id }, patientDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(PatientRequestModel requestModel, CancellationToken cancellationToken)
    {
        var validationResult = await _patientValidator.ValidateAsync(requestModel, cancellationToken);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.ToDictionary());

        var existingPatient = await _patientService.GetByIdAsync(requestModel.Name.Id, cancellationToken);
        if (existingPatient == null)
        {
            ModelState.AddModelError(nameof(HumanNameRequestModel.Id), string.Format(PATIENT_NOT_EXISTS_MESSAGE, nameof(HumanNameRequestModel.Id), requestModel.Name.Id));
            return BadRequest(ModelState);
        }

        var patientDto = requestModel.ToDto();

        await _patientService.UpdateAsync(patientDto, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _patientService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}
