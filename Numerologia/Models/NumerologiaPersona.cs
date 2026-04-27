using System.Globalization;
using System.Text;

namespace Numerologia.Models;
public class NumerologiaPersona
{
    public NumerologiaPersona(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public DateTime BirthDate { get; set; }


  //Numero de vida
    public int CalculateLifePathNumber()
    {
        var month = ReduceToSingleDigit(BirthDate.Month);
        var day = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(BirthDate.Year);

        return ReduceCoreNumber(month + day + year);
    }
//Numero de la expresion
    public int CalculateExpressionNumber()
    {
        return CalculateNameNumber(GetFullName());
    }
//Numero de los desafios
    public List<int> CalculateChallengeNumbers()
    {
        var month = ReduceToSingleDigit(BirthDate.Month);
        var day = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(BirthDate.Year);

        var first = ReduceToSingleDigit(Math.Abs(month - day));
        var second = ReduceToSingleDigit(Math.Abs(day - year));
        var third = ReduceToSingleDigit(Math.Abs(first - second));
        var fourth = ReduceToSingleDigit(Math.Abs(month - year));

        return new List<int> { first, second, third, fourth };
    }
//Numero de los pinaculos
    public List<int> CalculatePinnacles()
    {
        var month = ReduceToSingleDigit(BirthDate.Month);
        var day = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(BirthDate.Year);

        var first = ReduceCoreNumber(month + day);
        var second = ReduceCoreNumber(day + year);
        var third = ReduceCoreNumber(first + second);
        var fourth = ReduceCoreNumber(month + year);

        return new List<int> { first, second, third, fourth };
    }

//Vibracion anual
    public int CalculatePersonalYear(DateTime targetDate)
    {
        var birthMonth = ReduceToSingleDigit(BirthDate.Month);
        var birthDay = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(targetDate.Year);

        return ReduceCoreNumber(birthMonth + birthDay + year);
    }
//Vibracion mensual
    public int CalculatePersonalMonth(DateTime targetDate)
    {
        var personalYear = CalculatePersonalYear(targetDate);
        var month = ReduceToSingleDigit(targetDate.Month);

        return ReduceCoreNumber(personalYear + month);
    }
//Vibracion diaria
    public int CalculatePersonalDay(DateTime targetDate)
    {
        var personalMonth = CalculatePersonalMonth(targetDate);
        var day = ReduceToSingleDigit(targetDate.Day);

        return ReduceCoreNumber(personalMonth + day);
    }
//Numero de la herencia
    public int CalculateHeredityNumber()
    {
        return CalculateNameNumber(LastName);
    }
//Numero de la capsula
    public int CalculateCapsuleNumber()
    {
        return CalculateNameNumber(FirstName);
    }

    /*
//Resumen completo
    public ResumenPersona GetSummary(DateTime targetDate)
    {
        return new Summary
        {
            LifePathNumber = CalculateLifePathNumber(),
            ExpressionNumber = CalculateExpressionNumber(),
            ChallengeNumbers = CalculateChallengeNumbers(),
            Pinnacles = CalculatePinnacles(),
            PersonalYear = CalculatePersonalYear(targetDate),
            PersonalMonth = CalculatePersonalMonth(targetDate),
            PersonalDay = CalculatePersonalDay(targetDate),
            HeredityNumber = CalculateHeredityNumber(),
            CapsuleNumber = CalculateCapsuleNumber()
        };
    }
    */

//Calcula el número asociado a un nombre, 
//sumando el valor de cada letra y reduciendo el resultado a un solo dígito o a un número maestro.
    private int CalculateNameNumber(string value)
    {
        var total = 0;

        foreach (var letter in GetNormalizedLetters(value))
        {
            total += GetLetterValue(letter);
        }

        return ReduceCoreNumber(total);
    }

    private string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }


/// Valida que un valor requerido no sea nulo, vacío o solo espacios en blanco.
///  Si el valor es válido, se devuelve sin espacios al inicio o al final. 
/// Si el valor no es válido, se lanza una excepción ArgumentException indicando que el valor
///  no puede ser nulo o vacío, junto con el nombre del parámetro que causó la excepción.

    private string ValidateRequired(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", paramName);
        }

        return value.Trim();
    }
// Normaliza una cadena de texto eliminando acentos y caracteres especiales,
// y devuelve solo las letras en minúscula.
    private IEnumerable<char> GetNormalizedLetters(string value)
    {
        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new System.Text.StringBuilder(normalized.Length);

        foreach (var character in normalized)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(character);

            if (category == UnicodeCategory.NonSpacingMark)
            {
                continue;
            }

            if (char.IsLetter(character))
            {
                builder.Append(char.ToLowerInvariant(character));
            }
        }

        return builder.ToString();
    }

//Suma los dígitos de un número
    private int SumDigits(int number)
    {
        number = Math.Abs(number);

        if (number == 0)
        {
            return 0;
        }

        var sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }

//Reducir a un solo dígito
    private int ReduceToSingleDigit(int number)
    {
        number = Math.Abs(number);

        while (number > 9)
        {
            number = SumDigits(number);
        }

        return number;
    }

//Obtener el valor de la letra
    private int GetLetterValue(char c)
    {
        c = char.ToLowerInvariant(c);

        if (c < 'a' || c > 'z')
        {
            return 0;
        }

        return (c - 'a') + 1;
    }
//Reducir a un solo dígito o a un número maestro
    private int ReduceCoreNumber(int number)
    {
        number = Math.Abs(number);

        while (number > 9 && !IsMasterNumber(number))
        {
            number = SumDigits(number);
        }

        return number;
    }

    private bool IsMasterNumber(int number)
    {
        return number == 11 || number == 22 || number == 33|| number == 44;
    }


}