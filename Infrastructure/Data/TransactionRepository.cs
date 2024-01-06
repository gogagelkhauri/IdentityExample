using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

// public class TransactionRepository(AppDbContext dbContext)
//     : GenericRepository<Transaction>(dbContext), ITransactionRepository

public class TransactionRepository(AppDbContext dbContext) : GenericRepository<Transaction>(dbContext),ITransactionRepository
{
    
}