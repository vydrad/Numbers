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

        return new ResumenPersona
        {
            LifePathNumber = perfil.CalculateLifePathNumber(),
            ExpressionNumber = perfil.CalculateExpressionNumber(),
            ChallengeNumbers = perfil.CalculateChallengeNumbers(),
            Pinnacles = perfil.CalculatePinnacles(),
            PersonalYear = perfil.CalculatePersonalYear(targetDate),
            PersonalMonth = perfil.CalculatePersonalMonth(targetDate),
            PersonalDay = perfil.CalculatePersonalDay(targetDate),
            HeredityNumber = perfil.CalculateHeredityNumber(),
            CapsuleNumber = perfil.CalculateCapsuleNumber()
        };
    }

 public async Task<InterpretacionResultadoDto> GetLifePathInterpretationAsync(
        Persona persona,
        CancellationToken cancellationToken = default)
    {
        var number = GetLifePathNumber(persona);

        var interpretacion = await _interpretacionRepositorio.GetByNumberAndTypeAsync(
            number,
            "LifePath",
            cancellationToken);

        return new InterpretacionResultadoDto
        {
            Number = number,
            Type = "LifePath",
            Title = interpretacion?.Title,
            Description = interpretacion?.Description
        };
    }

    public int GetLifePathNumber(Persona persona) => CrearPerfil(persona).CalculateLifePathNumber();
    public int GetExpressionNumber(Persona persona) => CrearPerfil(persona).CalculateExpressionNumber();
    public List<int> GetChallengeNumbers(Persona persona) => new(CrearPerfil(persona).CalculateChallengeNumbers());
    public List<int> GetPinnacles(Persona persona) => new(CrearPerfil(persona).CalculatePinnacles());
    public int GetPersonalYear(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalYear(targetDate);
    public int GetPersonalMonth(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalMonth(targetDate);
    public int GetPersonalDay(Persona persona, DateTime targetDate) => CrearPerfil(persona).CalculatePersonalDay(targetDate);
    public int GetHeredityNumber(Persona persona) => CrearPerfil(persona).CalculateHeredityNumber();
    public int GetCapsuleNumber(Persona persona) => CrearPerfil(persona).CalculateCapsuleNumber();
    private NumerologiaPersona CrearPerfil(Persona persona)
    {
        return new NumerologiaPersona(
            persona.FirstName,
            persona.LastName,
            persona.BirthDate);
    }
    
}
