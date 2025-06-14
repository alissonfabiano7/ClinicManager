using ClinicManager.Application.Patients.Queries;
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
}
