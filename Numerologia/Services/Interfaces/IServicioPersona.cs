using Numerologia.DTOs;
using Numerologia.Models;

namespace Numerologia.Services;

public interface IServicioPersona
{
    int GetLifePathNumber(Persona persona);
    int GetExpressionNumber(Persona persona);
    List<int> GetChallengeNumbers(Persona persona);
    List<int> GetPinnacles(Persona persona);
    int GetPersonalYear(Persona persona, DateTime targetDate);
    int GetPersonalMonth(Persona persona, DateTime targetDate);
    int GetPersonalDay(Persona persona, DateTime targetDate);
    int GetHeredityNumber(Persona persona);
    int GetCapsuleNumber(Persona persona);
    ResumenPersona GetResumen(Persona persona, DateTime targetDate);

    Task<InterpretacionResultadoDto> GetLifePathInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);
}
