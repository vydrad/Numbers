using System.ComponentModel.DataAnnotations;

namespace Numerologia.DTOs;

public sealed class NumerologyRequestDto
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; init; }
}