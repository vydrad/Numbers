using Numerologia.Models;

namespace Numerologia.Repositorio;

public interface IInterpretationRepository
{
    Task<Interpretation?> GetByNumberAndType(
        int number,
        string type,
        CancellationToken cancellationToken = default);
}