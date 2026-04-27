using System.ComponentModel.DataAnnotations;

namespace Numerologia.DTOs;

public sealed class PersonaRequestDto : IValidatableObject
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; init; }

    public DateTime? TargetDate { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (BirthDate == default)
        {
            yield return new ValidationResult(
                "BirthDate is required.",
                new[] { nameof(BirthDate) });
        }

        if (BirthDate.Date > DateTime.Today)
        {
            yield return new ValidationResult(
                "BirthDate cannot be in the future.",
                new[] { nameof(BirthDate) });
        }

        if (TargetDate.HasValue && TargetDate.Value.Date < BirthDate.Date)
        {
            yield return new ValidationResult(
                "TargetDate cannot be earlier than BirthDate.",
                new[] { nameof(TargetDate) });
        }
    }
}
