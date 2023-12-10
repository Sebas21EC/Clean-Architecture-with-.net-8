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

        public async Task Remove(BankAccount bankAccount)
        {
            _context.BankAccounts.Remove(bankAccount);
            // Otros pasos necesarios...
            await _context.SaveChangesAsync();
        }

        //update
        public async Task Update(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);
            // Otros pasos necesarios...
            await _context.SaveChangesAsync();
        }

        public async Task<List<BankAccount>> GetAllAsync()
        {
            return await _context.BankAccounts.ToListAsync();
        }

        //public async Task<BankAccount?> GetByIdAsync(BankAccountId id)
        //{
        //    return await _context.BankAccounts.SingleOrDefaultAsync(c => c.Id == id);
        //}


    }
}
