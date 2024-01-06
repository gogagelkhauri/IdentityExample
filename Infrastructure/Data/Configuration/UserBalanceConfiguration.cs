using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
{
    public void Configure(EntityTypeBuilder<UserBalance> builder)
    {
        builder
            .HasOne(ub => ub.User)
            .WithOne(u => u.Balance)
            .HasForeignKey<UserBalance>(ub => ub.UserId)
            .IsRequired(false);
    }
}