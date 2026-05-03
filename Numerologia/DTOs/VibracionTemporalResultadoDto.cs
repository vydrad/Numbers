namespace Numerologia.DTOs;

public sealed class VibracionTemporalResultadoDto
{
    public int Year { get; init; }
    public int Age { get; init; }
    public string? PhysicalLetter { get; init; }
    public string? AffectiveLetter { get; init; }
    public string? SpiritualLetter { get; init; }
    public int PhysicalValue { get; init; }
    public int AffectiveValue { get; init; }
    public int SpiritualValue { get; init; }
    public int EssenceTotal { get; init; }
    public int EssenceNumber { get; init; }
}
