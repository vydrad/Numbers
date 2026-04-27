using Numerologia.Models;

namespace Numerologia.Repositorio;

public interface IInterpretacionRepositorio
{
    Task<InterpretacionPersona?> GetByNumberAndTypeAsync(
        int number,
        string type,
        CancellationToken cancellationToken = default);
}
