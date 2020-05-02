using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataAccessLayer.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => new { s.SubscriberId, s.ChanelAuthorId });

            builder.HasOne(s => s.Subscriber)
                .WithMany(s => s.Subscriptions)
                .HasForeignKey(s=>s.SubscriberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ch=>ch.ChanelAuthor)
                .WithMany(s=>s.Subscribers)
                .HasForeignKey(ch=>ch.ChanelAuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
