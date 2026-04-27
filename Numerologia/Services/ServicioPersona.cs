
using Numerologia.Models;
using Numerologia.Services;
  

public class ServicioPersona : IServicioPersona
{

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

    public int GetLifePathNumber(Persona persona)
    {
        return CrearPerfil(persona).CalculateLifePathNumber();
    }

    public int GetExpressionNumber(Persona persona)
    {
        return CrearPerfil(persona).CalculateExpressionNumber();
    }

    public List<int> GetChallengeNumbers(Persona persona)
    {
        return new List<int>(CrearPerfil(persona).CalculateChallengeNumbers());
    }

    public List<int> GetPinnacles(Persona persona)
    {
        return new List<int>(CrearPerfil(persona).CalculatePinnacles());
    }

    public int GetPersonalYear(Persona persona, DateTime targetDate)
    {
        return CrearPerfil(persona).CalculatePersonalYear(targetDate);
    }

    public int GetPersonalMonth(Persona persona, DateTime targetDate)
    {
        return CrearPerfil(persona).CalculatePersonalMonth(targetDate);
    }

    public int GetPersonalDay(Persona persona, DateTime targetDate)
    {
        return CrearPerfil(persona).CalculatePersonalDay(targetDate);
    }

    public int GetHeredityNumber(Persona persona)
    {
        return CrearPerfil(persona).CalculateHeredityNumber();
    }

    public int GetCapsuleNumber(Persona persona)
    {
        return CrearPerfil(persona).CalculateCapsuleNumber();
    }

    private static PerfilNumerologico CrearPerfil(Persona persona)
    {
        return new PerfilNumerologico(
            persona.FirstName,
            persona.LastName,
            persona.BirthDate);
    }
  
}