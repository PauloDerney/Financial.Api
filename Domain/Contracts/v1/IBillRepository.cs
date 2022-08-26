using Domain.Entities;

namespace Domain.Contracts.v1
{
    public interface IBillRepository
    {
        Task InsertAsync(Bill bill, CancellationToken cancellationToken = default);
    }
}