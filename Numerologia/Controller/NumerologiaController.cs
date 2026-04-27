
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
    public ActionResult<NumeroResultadoDto> GetLifePath([FromBody] PersonaRequestDto request)
    {
       var persona = CrearPersona(request);
       var number = _servicioPersona.GetLifePathNumber(persona);

          return Ok(new NumeroResultadoDto
         {
         Number = number
          });
    }
    [HttpPost("expression")]
    public ActionResult<NumeroResultadoDto> GetExpression([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetExpressionNumber(persona);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }

    [HttpPost("challenge-numbers")]
    public ActionResult<ListaNumerosResultadoDto> GetChallengeNumbers([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var numbers = _servicioPersona.GetChallengeNumbers(persona);

        return Ok(new ListaNumerosResultadoDto
        {
            Numbers = numbers
        });
    }   

    [HttpPost("pinnacles")]
    public ActionResult<ListaNumerosResultadoDto> GetPinnacles([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var numbers = _servicioPersona.GetPinnacles(persona);

        return Ok(new ListaNumerosResultadoDto
        {
            Numbers = numbers
        });
    }
    [HttpPost("personal-year")]
    public ActionResult<NumeroResultadoDto> GetPersonalYear([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetPersonalYear(persona, request.TargetDate ?? DateTime.Now);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }
    [HttpPost("personal-month")]
     public ActionResult<NumeroResultadoDto> GetPersonalMonth([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetPersonalMonth(persona, request.TargetDate ?? DateTime.Now);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }

    [HttpPost("personal-day")] 
    public ActionResult<NumeroResultadoDto> GetPersonalDay([FromBody] PersonaRequestDto request) 
    {
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetPersonalDay(persona, request.TargetDate ?? DateTime.Now);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }

    [HttpPost("heredity-number")]
    public ActionResult<NumeroResultadoDto> GetHeredityNumber([FromBody] PersonaRequestDto request)
    { 
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetHeredityNumber(persona);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }

    [HttpPost("capsule-number")]
    public ActionResult<NumeroResultadoDto> GetCapsuleNumber([FromBody] PersonaRequestDto request)
    {
        var persona = CrearPersona(request);
        var number = _servicioPersona.GetCapsuleNumber(persona);

        return Ok(new NumeroResultadoDto
        {
            Number = number
        });
    }

    [HttpPost("resumen")]
    public ActionResult<ResumenPersonaDto> GetResumen([FromBody] PersonaRequestDto request)
    {
        if (request.TargetDate is null)
        {
            return BadRequest("TargetDate is required for resumen.");
        }

        var persona = CrearPersona(request);
        var resumen = _servicioPersona.GetResumen(persona, request.TargetDate.Value);

        return Ok(new ResumenPersonaDto
        {
            LifePathNumber = resumen.LifePathNumber,
            ExpressionNumber = resumen.ExpressionNumber,
            ChallengeNumbers = resumen.ChallengeNumbers,
            Pinnacles = resumen.Pinnacles,
            PersonalYear = resumen.PersonalYear,
            PersonalMonth = resumen.PersonalMonth,
            PersonalDay = resumen.PersonalDay,
            HeredityNumber = resumen.HeredityNumber,
            CapsuleNumber = resumen.CapsuleNumber
        });
    }

}
