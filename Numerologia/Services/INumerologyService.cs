using Numerologia.DTOs;

namespace Numerologia.Services;

public interface INumerologyService
{
    Task<NumerologyResultDto> CalculateAsync(
        NumerologyRequestDto request,
        CancellationToken cancellationToken = default);
}