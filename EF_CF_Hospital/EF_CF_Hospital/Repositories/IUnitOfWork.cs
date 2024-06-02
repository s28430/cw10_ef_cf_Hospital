using Microsoft.EntityFrameworkCore.Storage;

namespace EF_CF_Hospital.Repositories;

public interface IUnitOfWork
{
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    public Task<int> CompleteAsync(CancellationToken cancellationToken);
    public void Dispose();
    public ValueTask DisposeAsync();
}