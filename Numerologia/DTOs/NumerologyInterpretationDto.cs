namespace Numerologia.DTOs;

public sealed class NumerologyInterpretationDto
{
    public int Number { get; init; }
    public string Type { get; init; } = string.Empty;
    public string? Title { get; init; }
    public string? Description { get; init; }
}