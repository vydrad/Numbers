using Microsoft.EntityFrameworkCore;
using Numerologia.Data;
using Numerologia.Models;

namespace Numerologia.Repositorio;

public sealed class InterpretacionRepositorio : IInterpretacionRepositorio
{
    private readonly NumerologiaDbContext _dbContext;

    public InterpretacionRepositorio(NumerologiaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<InterpretacionPersona?> GetByNumberAndTypeAsync(
        int number,
        string type,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Interpretations
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Number == number && x.Type == type,
                cancellationToken);
    }
}
