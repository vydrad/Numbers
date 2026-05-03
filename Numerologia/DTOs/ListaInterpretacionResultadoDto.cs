
namespace Numerologia.DTOs;
public sealed class ListaInterpretacionResultadoDto
{
    public string Type { get; init; } = string.Empty;
    public List<InterpretacionResultadoDto> Results { get; init; } = new();
}
