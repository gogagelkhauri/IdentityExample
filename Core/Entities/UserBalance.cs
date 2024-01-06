namespace Core.Entities;

public class UserBalance : Entity
{
    public decimal Balance { get; set; }
    public string UserId { get; set; }
    public virtual AppUser User { get; set; }
}