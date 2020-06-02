using GSP.Game.Domain.Entities;
using GSP.Game.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.Game.Data.Context.EntityMappings
{
    public class GameTypeConfiguration : IEntityTypeConfiguration<GameBase>
    {
        public void Configure(EntityTypeBuilder<GameBase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.DeveloperStudio)
                .WithMany()
                .HasForeignKey(p => p.DeveloperStudioId);

            builder.HasOne(p => p.Genre)
                .WithMany()
                .HasForeignKey(p => p.GenreId);

            builder.HasOne(p => p.Publisher)
                .WithMany()
                .HasForeignKey(p => p.PublisherId);

            builder.OwnsOne(
                p => p.GameDetails,
                detailsBuilder =>
                {
                    detailsBuilder.Property(p => p.Name).HasMaxLength(255).IsRequired();
                    detailsBuilder.Property(t => t.Description).HasMaxLength(500).IsRequired();
                    detailsBuilder.Property(t => t.AgeRestrictionSystem).HasDefaultValue(AgeRestrictionSystem.AllAges).HasConversion<string>().HasMaxLength(50).IsRequired();
                    detailsBuilder.Property(p => p.IconUri).HasConversion<string>().HasMaxLength(2048);
                    detailsBuilder.Property(p => p.PhotoUri).HasConversion<string>().HasMaxLength(2048);
                });

            builder.OwnsMany(
                p => p.Attachments,
                attachmentBuilder =>
                {
                    attachmentBuilder.ToTable("GameAttachments");
                    attachmentBuilder.HasKey(p => p.Id);
                    attachmentBuilder.WithOwner().HasForeignKey(t => t.GameId);

                    attachmentBuilder.Property(t => t.Description).HasMaxLength(500);
                    attachmentBuilder.Property(t => t.LinkUri).HasConversion<string>().HasMaxLength(2048).IsRequired();
                });

            builder
                .Metadata
                .FindNavigation(nameof(GameBase.Attachments))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}