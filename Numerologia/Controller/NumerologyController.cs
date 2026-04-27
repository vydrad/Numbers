using Microsoft.AspNetCore.Mvc;
using Numerologia.DTOs;
using Numerologia.Services;

namespace Numerologia.Controller;

[ApiController]
[Route("api/[controller]")]
public sealed class NumerologyController : ControllerBase
{
    private readonly INumerologyService _numerologyService;

    public NumerologyController(INumerologyService numerologyService)
    {
        _numerologyService = numerologyService;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(NumerologyResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NumerologyResultDto>> Calculate(
        [FromBody] NumerologyRequestDto request,
        CancellationToken cancellationToken)
    {
        var result = await _numerologyService.CalculateAsync(request, cancellationToken);
        return Ok(result);
    }
}