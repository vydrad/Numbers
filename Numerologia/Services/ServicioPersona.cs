using Numerologia.DTOs;
using Numerologia.Models;
using Numerologia.Repositorio;

namespace Numerologia.Services;

public sealed class ServicioPersona : IServicioPersona
{
    private readonly IInterpretacionRepositorio _interpretacionRepositorio;

    public ServicioPersona(IInterpretacionRepositorio interpretacionRepositorio)
    {
        _interpretacionRepositorio = interpretacionRepositorio;
    }

    public ResumenPersona GetResumen(Persona persona, DateTime targetDate)
    {
        var perfil = CrearPerfil(persona);
        var temporalVibration = perfil.CalculateTemporalAnnualVibration(targetDate);

        return new ResumenPersona
        {
            LifePathNumber = perfil.CalculateLifePathNumber(),
            AutoMotivationNumber = perfil.GetAutoMotivationNumber(),
            AutoImageNumber = perfil.GetAutoImageNumber(),
            AutoExpressionNumber = perfil.GetAutoExpressionNumber(),
            AutoMotivationChallengeNumber = perfil.GetAutoMotivationChallengeNumber(),
            AutoImageChallengeNumber = perfil.GetAutoImageChallengeNumber(),
            AutoExpressionChallengeNumber = perfil.GetAutoExpressionChallengeNumber(),
            ChallengeNumbers = perfil.CalculateChallengeNumbers(),
            Pinnacles = perfil.CalculatePinnacles(),
            PersonalYear = perfil.CalculatePersonalYear(targetDate),
            PersonalMonth = perfil.CalculatePersonalMonth(targetDate),
            PersonalDay = perfil.CalculatePersonalDay(targetDate),
            HeredityNumber = perfil.CalculateHeredityNumber(),
            CapsuleNumber = perfil.CalculateCapsuleNumber(),
            TemporalAnnualVibration = temporalVibration
        };
    }

    public int GetLifePathNumber(Persona persona) => CrearPerfil(persona).CalculateLifePathNumber();
    public int GetAutoExpressionNumber(Persona persona) => CrearPerfil(persona).GetAutoExpressionNumber();
    public int GetAutoMotivationNumber(Persona persona) => CrearPerfil(persona).GetAutoMotivationNumber();
    public int GetAutoImageNumber(Persona persona) => CrearPerfil(persona).GetAutoImageNumber();

    public List<int> GetChallengeNumbers(Persona persona) => new(CrearPerfil(persona).CalculateChallengeNumbers());
    public List<int> GetPinnacles(Persona persona) => new(CrearPerfil(persona).CalculatePinnacles());
    public int GetPersonalYear(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalYear(targetDate);
    public int GetPersonalMonth(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalMonth(targetDate);
    public int GetPersonalDay(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalDay(targetDate);
    public int GetHeredityNumber(Persona persona) => CrearPerfil(persona).CalculateHeredityNumber();
    public int GetCapsuleNumber(Persona persona) => CrearPerfil(persona).CalculateCapsuleNumber();
    public int GetAutoMotivationChallengeNumber(Persona persona) => CrearPerfil(persona).GetAutoMotivationChallengeNumber();
    public int GetAutoImageChallengeNumber(Persona persona) => CrearPerfil(persona).GetAutoImageChallengeNumber();
    public int GetAutoExpressionChallengeNumber(Persona persona) => CrearPerfil(persona).GetAutoExpressionChallengeNumber();
    public VibracionTemporalAnual GetTemporalAnnualVibration(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculateTemporalAnnualVibration(targetDate);
    public List<VibracionTemporalAnual> GetTemporalAnnualVibrationTable(Persona persona, int maxAge = 79) => CrearPerfil(persona).CalculateTemporalAnnualVibrationTable(maxAge);

    public async Task<InterpretacionResultadoDto> GetLifePathInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetLifePathNumber(persona);
        return await BuildInterpretationAsync(number, "LifePath", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetAutoMotivationInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoMotivationNumber(persona);
        return await BuildInterpretationAsync(number, "AutoMotivation", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetAutoImageInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoImageNumber(persona);
        return await BuildInterpretationAsync(number, "AutoImage", cancellationToken);
    }

        public async Task<InterpretacionResultadoDto> GetAutoExpressionInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoExpressionNumber(persona);
        return await BuildInterpretationAsync(number, "AutoExpression", cancellationToken);
    }


    public async Task<InterpretacionResultadoDto> GetPersonalYearInterpretationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
    {
        var number = GetPersonalYear(persona, targetDate);
        return await BuildInterpretationAsync(number, "PersonalYear", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetPersonalMonthInterpretationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
    {
        var number = GetPersonalMonth(persona, targetDate);
        return await BuildInterpretationAsync(number, "PersonalMonth", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetPersonalDayInterpretationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
    {
        var number = GetPersonalDay(persona, targetDate);
        return await BuildInterpretationAsync(number, "PersonalDay", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetHeredityNumberInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetHeredityNumber(persona);
        return await BuildInterpretationAsync(number, "HeredityNumber", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetCapsuleNumberInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetCapsuleNumber(persona);
        return await BuildInterpretationAsync(number, "CapsuleNumber", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetAutoMotivationChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoMotivationChallengeNumber(persona);
        return await BuildInterpretationAsync(number, "AutoMotivationChallenge", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetAutoImageChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoImageChallengeNumber(persona);
        return await BuildInterpretationAsync(number, "AutoImageChallenge", cancellationToken);
    }

    public async Task<InterpretacionResultadoDto> GetAutoExpressionChallengeInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetAutoExpressionChallengeNumber(persona);
        return await BuildInterpretationAsync(number, "AutoExpressionChallenge", cancellationToken);
    }

    public Task<VibracionTemporalResultadoDto> GetTemporalAnnualVibrationAsync(
        Persona persona,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
    {
        var vibration = GetTemporalAnnualVibration(persona, targetDate);

        return Task.FromResult(MapTemporalVibration(vibration));
    }

    public async Task<ListaInterpretacionResultadoDto> GetChallengeNumbersInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var numbers = GetChallengeNumbers(persona);

        return await BuildListInterpretationAsync(
            numbers,
            "ChallengeNumbers",
            cancellationToken);
    }

    public async Task<ListaInterpretacionResultadoDto> GetPinnaclesInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var numbers = GetPinnacles(persona);

        return await BuildListInterpretationAsync(
            numbers,
            "Pinnacles",
            cancellationToken);
    }

    private static NumerologiaPersona CrearPerfil(Persona persona)
    {
        return new NumerologiaPersona(
            persona.FirstName,
            persona.LastName,
            persona.BirthDate);
    }

    private async Task<InterpretacionResultadoDto> BuildInterpretationAsync(
        int number,
        string type,
        CancellationToken cancellationToken = default)
    {
        var interpretacion = await _interpretacionRepositorio.GetByNumberAndTypeAsync(
            number,
            type,
            cancellationToken);

        return new InterpretacionResultadoDto
        {
            Number = number,
            Type = type,
            Title = interpretacion?.Title,
            Description = interpretacion?.Description
        };
    }

    private async Task<ListaInterpretacionResultadoDto> BuildListInterpretationAsync(
        List<int> numbers,
        string type,
        CancellationToken cancellationToken = default)
    {
        var results = new List<InterpretacionResultadoDto>();

        foreach (var number in numbers)
        {
            results.Add(await BuildInterpretationAsync(number, type, cancellationToken));
        }

        return new ListaInterpretacionResultadoDto
        {
            Type = type,
            Results = results
        };
    }

    private static VibracionTemporalResultadoDto MapTemporalVibration(VibracionTemporalAnual vibration)
    {
        return new VibracionTemporalResultadoDto
        {
            Year = vibration.Year,
            Age = vibration.Age,
            PhysicalLetter = vibration.PhysicalLetter,
            AffectiveLetter = vibration.AffectiveLetter,
            SpiritualLetter = vibration.SpiritualLetter,
            PhysicalValue = vibration.PhysicalValue,
            AffectiveValue = vibration.AffectiveValue,
            SpiritualValue = vibration.SpiritualValue,
            EssenceTotal = vibration.EssenceTotal,
            EssenceNumber = vibration.EssenceNumber
        };
    }
}
