using Numerologia.DTOs;
using Numerologia.Models;

namespace Numerologia.Services;

public interface IServicioPersona
{
    int GetLifePathNumber(Persona persona);
    int GetAutoMotivationNumber(Persona persona);
    int GetAutoImageNumber(Persona persona);
    int GetAutoExpressionNumber(Persona persona);
    List<int> GetChallengeNumbers(Persona persona);
    List<int> GetPinnacles(Persona persona);
    int GetPersonalYear(Persona persona, DateTime targetDate);
    int GetPersonalMonth(Persona persona, DateTime targetDate);
    int GetPersonalDay(Persona persona, DateTime targetDate);
    int GetHeredityNumber(Persona persona);
    int GetCapsuleNumber(Persona persona);
    int GetAutoMotivationChallengeNumber(Persona persona);
    int GetAutoImageChallengeNumber(Persona persona);
    int GetAutoExpressionChallengeNumber(Persona persona);
    VibracionTemporalAnual GetTemporalAnnualVibration(Persona persona, DateTime targetDate);
    List<VibracionTemporalAnual> GetTemporalAnnualVibrationTable(Persona persona, int maxAge = 79);
    ResumenPersona GetResumen(Persona persona, DateTime targetDate);

//Declaro todos los metodos de la interface que vana manejar los Dtos
    Task<InterpretacionResultadoDto> GetLifePathInterpretationAsync(
    Persona persona,
    CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoMotivationInterpretationAsync(
    Persona persona,
    CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoImageInterpretationAsync(
    Persona persona,
    CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoExpressionInterpretationAsync(
    Persona persona,
    CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetPersonalYearInterpretationAsync(
    Persona persona,
    DateTime targetDate,
     CancellationToken cancellationToken = default );

    Task<InterpretacionResultadoDto> GetPersonalMonthInterpretationAsync(
    Persona persona,
    DateTime targetDate,
     CancellationToken cancellationToken = default );

    Task<InterpretacionResultadoDto> GetPersonalDayInterpretationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default);
    
    Task<InterpretacionResultadoDto> GetHeredityNumberInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);
    
    Task<InterpretacionResultadoDto>GetCapsuleNumberInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoMotivationChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoImageChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);

    Task<InterpretacionResultadoDto> GetAutoExpressionChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default);

    Task<VibracionTemporalResultadoDto> GetTemporalAnnualVibrationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default);
    
    Task<ListaInterpretacionResultadoDto> GetChallengeNumbersInterpretationAsync(
    Persona persona,
    CancellationToken cancellationToken = default);

    Task<ListaInterpretacionResultadoDto> GetPinnaclesInterpretationAsync(
    Persona persona, CancellationToken cancellationToken = default);
    
}
