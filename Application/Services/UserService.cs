using Core.Entities;
using Core.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBalanceRepository _balanceRepository;
    private readonly ITransactionRepository _transactionRepository;


    public UserService(IUnitOfWork unitOfWork, IBalanceRepository balanceRepository, ITransactionRepository transactionRepository)
    {
        _unitOfWork = unitOfWork;
        _balanceRepository = balanceRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<string> CreateBalance()
    {
        var balance = new UserBalance()
        {
            Balance = 0,
        };
        await _balanceRepository.AddAsync(balance);
        await _unitOfWork.CommitAsync();
        return balance.Id;
    }

    public async Task SetBalanceUser(string balanceId, string userId)
    {
        var balance = await _balanceRepository.GetByIdAsync(balanceId);
        balance.UserId = userId;
        _balanceRepository.Update(balance);
        await _unitOfWork.CommitAsync();
    }

    public async Task Deposit(string balanceId, string userId, decimal amount)
    {
        var transaction = new Transaction()
        {
            UserId = userId,
            Amount = amount,
            TransactionType = TransactionType.Deposit,
            CreatedAt = DateTime.Now
        };
        await _transactionRepository.AddAsync(transaction);
        
        var balance = await _balanceRepository.GetByIdAsync(balanceId);
        balance.Balance += amount;
        _balanceRepository.Update(balance);
        await _unitOfWork.CommitAsync();
    }
    
    public async Task Withdraw(string balanceId, string userId, decimal amount)
    {
        var transaction = new Transaction()
        {
            UserId = userId,
            Amount = amount,
            TransactionType = TransactionType.Withdrawal,
            CreatedAt = DateTime.Now
        };
        await _transactionRepository.AddAsync(transaction);
        
        var balance = await _balanceRepository.GetByIdAsync(balanceId);
        if (balance.Balance >= amount)
        {
            balance.Balance -= amount;
            _balanceRepository.Update(balance);
            await _unitOfWork.CommitAsync();
        }
    }

    public async Task Transfer(string currentUserBalanceId, string currentUserId,
        string destinationUserBalanceId, string destinationUserId,
        decimal amount)
    {
        var transaction = new Transaction()
        {
            UserId = currentUserId,
            Amount = amount,
            TransactionType = TransactionType.Transfer,
            CreatedAt = DateTime.Now,
            OtherPartyUserId = destinationUserId
        };
        await _transactionRepository.AddAsync(transaction);
        var currentUserBalance = await _balanceRepository.GetByIdAsync(currentUserBalanceId);
        if (currentUserBalance.Balance >= amount)
        {
            currentUserBalance.Balance -= amount;
            _balanceRepository.Update(currentUserBalance);

            var destinationUserBalance = await _balanceRepository.GetByIdAsync(destinationUserBalanceId);
            destinationUserBalance.Balance += amount;
            await _unitOfWork.CommitAsync();
        }
    }
}