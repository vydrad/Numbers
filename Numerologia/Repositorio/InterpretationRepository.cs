using System.Threading;
using Microsoft.EntityFrameworkCore;
using Numerologia.Data;
using Numerologia.Models;

namespace Numerologia.Repositorio;

public sealed class InterpretationRepository : IInterpretationRepository
{
    private readonly NumerologiaDbContext _dbContext;

    public InterpretationRepository(NumerologiaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Interpretation?> GetByNumberAndType(
        int number,
        string type,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Interpretations
            .AsNoTracking()
            .FirstOrDefaultAsync(
                (Interpretation x) => x.Number == number && x.Type == type,
                cancellationToken);
    }
}