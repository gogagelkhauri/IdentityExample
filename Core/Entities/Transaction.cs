namespace Core.Entities;

public class Transaction : Entity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; } 
    public string? OtherPartyUserId { get; set; }
    public AppUser OtherPartyUser { get; set; }
    public DateTime CreatedAt { get; set; }
}