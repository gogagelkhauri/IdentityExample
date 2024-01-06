using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

public class BalanceRepository(AppDbContext dbContext) : GenericRepository<UserBalance>(dbContext), IBalanceRepository
{
    
}