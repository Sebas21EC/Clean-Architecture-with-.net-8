using Domain.Entities.BankAccounts;
using MediatR;

namespace Application.CQRS.BankAccounts.GetAll
{
  

        internal sealed class GetAllBankAccountsCommandHandler : IRequestHandler<GetAllBankAccountsCommand, List<BankAccount>>
        {
            private readonly IBankAccountRepository _bankAccountRepository;

            public GetAllBankAccountsCommandHandler(IBankAccountRepository bankAccountRepository)
            {
                _bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
            }

            public async Task<List<BankAccount>> Handle(GetAllBankAccountsCommand query, CancellationToken cancellationToken)
            {
                // Lógica para obtener todas las cuentas bancarias
                var bankAccounts = await _bankAccountRepository.GetAllAsync();
                return bankAccounts.ToList();
            }
        }
    
}
