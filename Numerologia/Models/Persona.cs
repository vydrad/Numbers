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

    private string ValidateRequired(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", paramName);
        }

        return value.Trim();
    }


}
