namespace Numerologia.Models;

public sealed class Interpretation
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}