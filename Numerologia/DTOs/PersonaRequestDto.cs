namespace Numerologia.DTOs;

public sealed class PersonaRequestDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public DateTime? TargetDate { get; init; }
}
