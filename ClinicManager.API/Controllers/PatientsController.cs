using ClinicManager.Application.Patients.Commands.CreatePatient;
using ClinicManager.Application.Patients.Commands.DeletePatient;
using ClinicManager.Application.Patients.Commands.UpdatePatient;
using ClinicManager.Application.Patients.Queries;
using ClinicManager.Application.Patients.Queries.GetAllPatients;
using ClinicManager.Application.Patients.Queries.GetPatientById;
using ClinicManager.Application.Patients.Queries.SearchPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPatientsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPatientByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("{search}")]
    public async Task<IActionResult> Search(string search)
    {
        var result = await _mediator.Send(new SearchPatientsQuery(search));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreatePatientCommand command, CancellationToken ct)
    {
        var id = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePatientCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeletePatientCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
