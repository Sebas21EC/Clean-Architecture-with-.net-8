using Domain.Entities.BankAccounts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Infraestructure.Persistence
{
    public class BankAccountIdValueConverter : ValueConverter<BankAccountId, string>
    {
        public BankAccountIdValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                  id => id.Value,
                  value => BankAccountId.Create(value),
                  mappingHints)
        {
        }
    }
}
