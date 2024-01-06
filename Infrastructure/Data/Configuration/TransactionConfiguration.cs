using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(t => t.OtherPartyUser)
            .WithMany(u => u.Transfers)
            .HasForeignKey(t => t.OtherPartyUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasPrincipalKey(u => u.Id)
            .IsRequired(false);
        
        // builder.Property(o => o.OtherPartyUser)
        //     .IsRequired(false)
        //     .HasColumnType("uniqueidentifier");
    }
}