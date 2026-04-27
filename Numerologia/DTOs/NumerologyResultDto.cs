namespace Numerologia.DTOs;

public sealed class NumerologyResultDto
{
    public NumerologyInterpretationDto LifePath { get; init; } = new();
    public NumerologyInterpretationDto Expression { get; init; } = new();
    public NumerologyInterpretationDto PersonalYear { get; init; } = new();
    public NumerologyInterpretationDto Heredity { get; init; } = new();
}