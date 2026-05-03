
using Microsoft.AspNetCore.Mvc;
using Numerologia.DTOs;
using Numerologia.Models;
using Numerologia.Services;

namespace Numerologia.Controller;
[ApiController]
[Route("api/numerologia")]
public class NumerologiaController : ControllerBase
{
    private readonly IServicioPersona _servicioPersona;

    public NumerologiaController(IServicioPersona servicioPersona)
    {
        _servicioPersona = servicioPersona;
    }
    private static Persona CrearPersona(PersonaRequestDto request)
    {
        return new Persona(request.FirstName, request.LastName, request.BirthDate);
    }

    [HttpPost("life-path")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetLifePath(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = new Persona(request.FirstName, request.LastName, request.BirthDate);

        var result = await _servicioPersona.GetLifePathInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

   [HttpPost("auto-expression")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoExpression(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = new Persona(request.FirstName, request.LastName, request.BirthDate);

        var result = await _servicioPersona.GetAutoExpressionInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("auto-motivation")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoMotivation(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetAutoMotivationInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }


    [HttpPost("auto-image")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoImage(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetAutoImageInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("auto-expression")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetSelfExpression(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetSelfExpressionInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }




    [HttpPost("personal-year")] 
    public async Task<ActionResult<InterpretacionResultadoDto>> GetPersonalYear(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetPersonalYearInterpretationAsync(
            persona,
            request.TargetDate ?? DateTime.Today,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("personal-month")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetPersonalMonth(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetPersonalMonthInterpretationAsync(
            persona,
            request.TargetDate ?? DateTime.Today,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("personal-day")] 
    public async Task<ActionResult<InterpretacionResultadoDto>> GetPersonalDay(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetPersonalDayInterpretationAsync(
            persona,
            request.TargetDate ?? DateTime.Today,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("heredity-number")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetHeredityNumber(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetHeredityNumberInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("capsule-number")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetCapsuleNumber
    ([FromBody] PersonaRequestDto request
    , CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

       var result = await _servicioPersona.GetCapsuleNumberInterpretationAsync (
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("auto-motivation-challenge")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoMotivationChallenge(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetAutoMotivationChallengeInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("auto-image-challenge")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoImageChallenge(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetAutoImageChallengeInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("auto-expression-challenge")]
    public async Task<ActionResult<InterpretacionResultadoDto>> GetAutoExpressionChallenge(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = CrearPersona(request);

        var result = await _servicioPersona.GetAutoExpressionChallengeInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("resumen")]
    public ActionResult<ResumenResultadoDto> GetResumen
    ([FromBody] PersonaRequestDto request)
    {
        if (request.TargetDate is null)
        {
            return BadRequest("TargetDate is required for resumen.");
        }

        var persona = CrearPersona(request);
        var resumen = _servicioPersona.GetResumen(persona, request.TargetDate.Value);

        return Ok(new ResumenResultadoDto
        {
            LifePathNumber = resumen.LifePathNumber,
            AutoMotivationNumber = resumen.AutoMotivationNumber,
            AutoImageNumber = resumen.AutoImageNumber,
            AutoExpressionNumber = resumen.AutoExpressionNumber,
            AutoMotivationChallengeNumber = resumen.AutoMotivationChallengeNumber,
            AutoImageChallengeNumber = resumen.AutoImageChallengeNumber,
            AutoExpressionChallengeNumber = resumen.AutoExpressionChallengeNumber,
            ChallengeNumbers = resumen.ChallengeNumbers,
            Pinnacles = resumen.Pinnacles,
            PersonalYear = resumen.PersonalYear,
            PersonalMonth = resumen.PersonalMonth,
            PersonalDay = resumen.PersonalDay,
            HeredityNumber = resumen.HeredityNumber,
            CapsuleNumber = resumen.CapsuleNumber,
            TemporalAnnualVibration = resumen.TemporalAnnualVibration is null
                ? null
                : new VibracionTemporalResultadoDto
                {
                    Year = resumen.TemporalAnnualVibration.Year,
                    Age = resumen.TemporalAnnualVibration.Age,
                    PhysicalLetter = resumen.TemporalAnnualVibration.PhysicalLetter,
                    AffectiveLetter = resumen.TemporalAnnualVibration.AffectiveLetter,
                    SpiritualLetter = resumen.TemporalAnnualVibration.SpiritualLetter,
                    PhysicalValue = resumen.TemporalAnnualVibration.PhysicalValue,
                    AffectiveValue = resumen.TemporalAnnualVibration.AffectiveValue,
                    SpiritualValue = resumen.TemporalAnnualVibration.SpiritualValue,
                    EssenceTotal = resumen.TemporalAnnualVibration.EssenceTotal,
                    EssenceNumber = resumen.TemporalAnnualVibration.EssenceNumber
                }
        });
    }

    [HttpPost("temporal-vibration")]
    public async Task<ActionResult<VibracionTemporalResultadoDto>> GetTemporalVibration(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        if (request.TargetDate is null)
        {
            return BadRequest("TargetDate is required for temporal vibration.");
        }

        var persona = CrearPersona(request);
        var result = await _servicioPersona.GetTemporalAnnualVibrationAsync(
            persona,
            request.TargetDate.Value,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("challenge-numbers")]
    public async Task<ActionResult<ListaInterpretacionResultadoDto>> GetChallengeNumbers(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = new Persona(request.FirstName, request.LastName, request.BirthDate);

        var result = await _servicioPersona.GetChallengeNumbersInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("pinnacles")]
    public async Task<ActionResult<ListaInterpretacionResultadoDto>> GetPinnacles(
        [FromBody] PersonaRequestDto request,
        CancellationToken cancellationToken)
    {
        var persona = new Persona(request.FirstName, request.LastName, request.BirthDate);

        var result = await _servicioPersona.GetPinnaclesInterpretationAsync(
            persona,
            cancellationToken);

        return Ok(result); 
    }


}
