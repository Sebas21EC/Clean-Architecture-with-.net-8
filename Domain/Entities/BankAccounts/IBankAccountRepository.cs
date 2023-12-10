using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BankAccounts
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetByIdAsync(BankAccountId id);
        Task Add (BankAccount bankAccount);
        Task Remove(BankAccount bankAccount);
        Task Update(BankAccount bankAccount);
        Task<List<BankAccount>> GetAllAsync();

    }
}
