using System.ComponentModel.DataAnnotations;

namespace Numerologia.Models;

public sealed class Persona
{
       // public int Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime BirthDate { get; }
    
   // public EmailAddressAttribute Email { get; set; }
    public Persona(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = ValidateRequired(firstName, nameof(firstName));
        LastName = ValidateRequired(lastName, nameof(lastName));
        BirthDate = birthDate.Date;
        
    }

    private static string ValidateRequired(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", paramName);
        }

        return value.Trim();
    }
}
