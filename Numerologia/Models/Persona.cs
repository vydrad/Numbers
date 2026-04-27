using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace Numerologia;

public class Persona
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }


    public void NumerologyProfile(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = ValidateRequired(firstName, nameof(firstName));
        LastName = ValidateRequired(lastName, nameof(lastName));
        BirthDate = birthDate.Date;
    }

    public int CalculateLifePathNumber()
    {
        var month = ReduceToSingleDigit(BirthDate.Month);
        var day = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(BirthDate.Year);

        return ReduceCoreNumber(month + day + year);
    }

    public int CalculateExpressionNumber()
    {
        return CalculateNameNumber(GetFullName());
    }

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

    public int CalculatePersonalYear(DateTime targetDate)
    {
        var birthMonth = ReduceToSingleDigit(BirthDate.Month);
        var birthDay = ReduceToSingleDigit(BirthDate.Day);
        var year = ReduceToSingleDigit(targetDate.Year);

        return ReduceCoreNumber(birthMonth + birthDay + year);
    }

    public int CalculatePersonalMonth(DateTime targetDate)
    {
        var personalYear = CalculatePersonalYear(targetDate);
        var month = ReduceToSingleDigit(targetDate.Month);

        return ReduceCoreNumber(personalYear + month);
    }

    public int CalculatePersonalDay(DateTime targetDate)
    {
        var personalMonth = CalculatePersonalMonth(targetDate);
        var day = ReduceToSingleDigit(targetDate.Day);

        return ReduceCoreNumber(personalMonth + day);
    }

    public int CalculateHeredityNumber()
    {
        return CalculateNameNumber(LastName);
    }

    public int CalculateCapsuleNumber()
    {
        return CalculateNameNumber(FirstName);
    }

    public Summary GetSummary(DateTime targetDate)
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

    private string ValidateRequired(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", paramName);
        }

        return value.Trim();
    }

    private IEnumerable<char> GetNormalizedLetters(string value)
    {
        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder(normalized.Length);

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

    private int ReduceToSingleDigit(int number)
    {
        number = Math.Abs(number);

        while (number > 9)
        {
            number = SumDigits(number);
        }

        return number;
    }

    private int GetLetterValue(char c)
    {
        c = char.ToLowerInvariant(c);

        if (c < 'a' || c > 'z')
        {
            return 0;
        }

        return (c - 'a') + 1;
    }

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
        return number == 11 || number == 22 || number == 33;
    }

    public sealed class Summary
    {
        public int LifePathNumber { get; init; }
        public int ExpressionNumber { get; init; }
        public List<int> ChallengeNumbers { get; init; } = new();
        public List<int> Pinnacles { get; init; } = new();
        public int PersonalYear { get; init; }
        public int PersonalMonth { get; init; }
        public int PersonalDay { get; init; }
        public int HeredityNumber { get; init; }
        public int CapsuleNumber { get; init; }
    }


}
