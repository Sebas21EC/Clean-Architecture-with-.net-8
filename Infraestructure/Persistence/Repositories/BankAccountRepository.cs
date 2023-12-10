using Domain.Entities.BankAccounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(BankAccount));
        }

        public async Task Add(BankAccount bankAccount)=> await _context.BankAccounts.AddAsync(bankAccount);

        public async Task<BankAccount?> GetByIdAsync(BankAccountId id)=> await _context.BankAccounts.SingleOrDefaultAsync(c=> c.Id==id);
    }
}
