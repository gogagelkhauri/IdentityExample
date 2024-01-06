using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser, IAggregateRoot
{
    public string BalanceId { get; set; }
    public UserBalance Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
    public List<Transaction> Transfers { get; set; }
}