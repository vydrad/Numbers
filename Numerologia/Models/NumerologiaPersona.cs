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


  //Numero de Destino
    public int CalculateLifePathNumber()
    {
        var total = SumDigits(BirthDate.Month) + SumDigits(BirthDate.Day) + SumDigits(BirthDate.Year);
        return ReduceCoreNumber(total);
    }
//Numero de la expresion
    public int CalculateExpressionNumber()
    {
        return CalculateNameNumber(GetFullName());
    }

    public int GetAutoExpressionNumber()
    {
        return CalculateExpressionNumber();
    }

    public int CalculateAutoMotivationNumber()
    {
        return CalculateFilteredNameNumber(GetFullName(), IsVowel);
    }

    public int GetAutoMotivationNumber()
    {
        return CalculateAutoMotivationNumber();
    }

    public List<int> CalculateAutoMotivationInstinctNumbers()
    {
        return GetNormalizedWords(GetFullName())
            .Select(word => CalculateFilteredNameNumber(word, IsVowel))
            .ToList();
    }

    public int CalculateAutoImageNumber()
    {
        return CalculateFilteredNameNumber(GetFullName(), IsConsonant);
    }

    public int GetAutoImageNumber()
    {
        return CalculateAutoImageNumber();
    }

    public int CalculateSelfExpressionNumber()
    {
        return CalculateExpressionNumber();
    }

    public int GetAutoExpressionChallengeBaseNumber()
    {
        return GetAutoExpressionNumber();
    }

    public int CalculateAutoMotivationChallengeNumber()
    {
        var firstVowel = GetFirstMatchingLetter(GetFirstWord(FirstName), IsVowel);
        var lastVowel = GetLastMatchingLetter(GetLastWord(LastName), IsVowel);

        return CalculateLetterChallenge(firstVowel, lastVowel);
    }

    public int GetAutoMotivationChallengeNumber()
    {
        return CalculateAutoMotivationChallengeNumber();
    }

    public int CalculateAutoImageChallengeNumber()
    {
        var firstConsonant = GetFirstMatchingLetter(GetFirstWord(FirstName), IsConsonant);
        var lastConsonant = GetLastMatchingLetter(GetFullName(), IsConsonant);

        return CalculateLetterChallenge(firstConsonant, lastConsonant);
    }

    public int GetAutoImageChallengeNumber()
    {
        return CalculateAutoImageChallengeNumber();
    }

    public int CalculateSelfExpressionChallengeNumber()
    {
        return CalculateChallengeDifference(
            CalculateAutoMotivationChallengeNumber(),
            CalculateAutoImageChallengeNumber());
    }

    public int GetAutoExpressionChallengeNumber()
    {
        return CalculateSelfExpressionChallengeNumber();
    }

    public VibracionTemporalAnual CalculateTemporalAnnualVibration(DateTime targetDate)
    {
        var year = targetDate.Year;
        var age = Math.Max(1, year - BirthDate.Year);
        var planeWords = GetPlaneWords();

        var physicalLetter = GetActiveTransitLetter(planeWords[0], age);
        var affectiveLetter = GetActiveTransitLetter(planeWords[1], age);
        var spiritualLetter = GetActiveTransitLetter(planeWords[2], age);

        var physicalValue = GetTransitDisplayValue(physicalLetter);
        var affectiveValue = GetTransitDisplayValue(affectiveLetter);
        var spiritualValue = GetTransitDisplayValue(spiritualLetter);
        var essenceTotal = physicalValue + affectiveValue + spiritualValue;

        return new VibracionTemporalAnual
        {
            Year = year,
            Age = age,
            PhysicalLetter = ToDisplayLetter(physicalLetter),
            AffectiveLetter = ToDisplayLetter(affectiveLetter),
            SpiritualLetter = ToDisplayLetter(spiritualLetter),
            PhysicalValue = physicalValue,
            AffectiveValue = affectiveValue,
            SpiritualValue = spiritualValue,
            EssenceTotal = essenceTotal,
            EssenceNumber = ReduceCoreNumber(essenceTotal)
        };
    }

    public List<VibracionTemporalAnual> CalculateTemporalAnnualVibrationTable(int maxAge = 79)
    {
        var table = new List<VibracionTemporalAnual>();

        for (var age = 1; age <= maxAge; age++)
        {
            var year = BirthDate.Year + age;
            table.Add(CalculateTemporalAnnualVibration(new DateTime(year, 1, 1)));
        }

        return table;
    }
//Numero de los desafios
    public List<int> CalculateChallengeNumbers()
    {
        var month = ReduceToSingleDigit(BirthDate.Month);
        var day = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(BirthDate.Year);

        var first = CalculateChallengeDifference(month, day);
        var second = CalculateChallengeDifference(day, year);
        var third = CalculateChallengeDifference(first, second);
        var fourth = CalculateChallengeDifference(month, year);

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

    public List<int> CalculatePinnacleTransitionAges()
    {
        var lifePathRoot = ReduceToSingleDigit(CalculateLifePathNumber());
        var firstEnd = 36 - lifePathRoot;
        var secondEnd = firstEnd + 9;
        var thirdEnd = secondEnd + 9;
        var fourthStarts = thirdEnd + 1;

        return new List<int> { firstEnd, secondEnd, thirdEnd, fourthStarts };
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
        return CalculateFilteredNameNumber(value, _ => true);
    }

    private int CalculateFilteredNameNumber(string value, Func<char, bool> filter)
    {
        var total = 0;

        foreach (var letter in GetNormalizedLetters(value))
        {
            if (filter(letter))
            {
                total += GetLetterValue(letter);
            }
        }

        return ReduceCoreNumber(total);
    }

    private string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    private string?[] GetPlaneWords()
    {
        var words = GetNormalizedWords(GetFullName());

        return
        [
            words.ElementAtOrDefault(0),
            words.ElementAtOrDefault(1),
            words.ElementAtOrDefault(2)
        ];
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
        return NormalizeToLetters(value);
    }

    private string NormalizeToLetters(string value)
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

    private List<string> GetNormalizedWords(string value)
    {
        return value
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(NormalizeToLetters)
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .ToList();
    }

    private string GetFirstWord(string value)
    {
        return value
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .FirstOrDefault() ?? string.Empty;
    }

    private string GetLastWord(string value)
    {
        return value
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .LastOrDefault() ?? string.Empty;
    }

    private char? GetFirstMatchingLetter(string value, Func<char, bool> predicate)
    {
        foreach (var letter in GetNormalizedLetters(value))
        {
            if (predicate(letter))
            {
                return letter;
            }
        }

        return null;
    }

    private char? GetLastMatchingLetter(string value, Func<char, bool> predicate)
    {
        var letters = GetNormalizedLetters(value).ToList();

        for (var index = letters.Count - 1; index >= 0; index--)
        {
            if (predicate(letters[index]))
            {
                return letters[index];
            }
        }

        return null;
    }

    private int CalculateLetterChallenge(char? left, char? right)
    {
        var leftValue = left.HasValue ? GetLetterValue(left.Value) : 0;
        var rightValue = right.HasValue ? GetLetterValue(right.Value) : 0;

        return CalculateChallengeDifference(leftValue, rightValue);
    }

    private char? GetActiveTransitLetter(string? word, int age)
    {
        if (string.IsNullOrWhiteSpace(word) || age <= 0)
        {
            return null;
        }

        var letters = NormalizeToLetters(word).ToCharArray();

        if (letters.Length == 0)
        {
            return null;
        }

        var remainingYears = age - 1;

        while (true)
        {
            foreach (var letter in letters)
            {
                var duration = GetTransitDuration(letter);

                if (remainingYears < duration)
                {
                    return letter;
                }

                remainingYears -= duration;
            }
        }
    }

    private int GetTransitDuration(char letter)
    {
        return ReduceToSingleDigit(GetLetterValue(letter));
    }

    private int GetTransitDisplayValue(char? letter)
    {
        return letter.HasValue ? GetLetterValue(letter.Value) : 0;
    }

    private string? ToDisplayLetter(char? letter)
    {
        return letter.HasValue ? char.ToUpperInvariant(letter.Value).ToString() : null;
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

    private int CalculateChallengeDifference(int left, int right)
    {
        return ReduceToSingleDigit(Math.Abs(left - right));
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

    private bool IsVowel(char c)
    {
        return c is 'a' or 'e' or 'i' or 'o' or 'u';
    }

    private bool IsConsonant(char c)
    {
        return char.IsLetter(c) && !IsVowel(c);
    }
//Reducir a un solo dígito o a un número maestro
    private int ReduceCoreNumber(int number)
    {
        if(IsMasterNumber(number))
        {
            return number;
        }
        number = Math.Abs(number);

        while (number > 9 && !IsMasterNumber(number))
        {
            number = SumDigits(number);
        }

        return number;
    }

    private bool IsMasterNumber(int number)
    {
        return number == 11 || number == 22 || number == 33;
    }


}
