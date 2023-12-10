using Domain.Entities.BankAccounts;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Configuration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            //    public BankAccountId Id { get; private set; }
            //public string? Number { get; private set; }
            //public string? BankName { get; private set; }
            //public string? Name { get; private set; }
            //public string? Details { get; private set; }
            //public bool status { get; private set; }
            //public PhoneNumber? PhoneNumber { get; private set; }

            builder.ToTable("BankAccounts");

            builder.HasKey(b => b.Id);
            //builder.Property(b => b.Id).HasConversion(b => b.Value, b => new BankAccountId(b));
            builder.HasIndex(b => b.Number).IsUnique();
            builder.Property(b => b.BankName).HasMaxLength(50);
            builder.Property(b => b.Name).HasMaxLength(50);

            //Para ignoar
            //builder.Ignore(b => b.Name);

            builder.Property(b => b.Details).HasMaxLength(250);
            builder.Property(b => b.status).IsRequired(true);
            builder.Property(b => b.PhoneNumber).HasConversion(b => b.Value, b => PhoneNumber.Create(b)!).HasMaxLength(10);

        }
    }
}
