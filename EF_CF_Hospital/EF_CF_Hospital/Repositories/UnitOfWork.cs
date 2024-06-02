using System.Data;
using EF_CF_Hospital.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace EF_CF_Hospital.Repositories;

public class UnitOfWork(HospitalDbContext dbContext) : IUnitOfWork
{
    private readonly HospitalDbContext _dbContext = dbContext;
    
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}