using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Contacts.Domain.Models;

namespace Contacts.Infrastructure.EntityConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.DOB);

            builder.Property(c => c.Address)
                .HasMaxLength(500);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(c => c.IBAN)
                .HasMaxLength(34);
        }
    }
}
