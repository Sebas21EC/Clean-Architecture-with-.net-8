using Domain.Entities.BankAccounts;
using MediatR;


namespace Application.CQRS.BankAccounts.GetById
{

    internal sealed class GetBankAccountByIdCommandHandler : IRequestHandler<GetBankAccountByIdCommand, BankAccount>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public GetBankAccountByIdCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
        }

        public async Task<BankAccount> Handle(GetBankAccountByIdCommand query, CancellationToken cancellationToken)
        {
            // Lógica para obtener una cuenta bancaria por ID
            var bankAccount = await _bankAccountRepository.GetByIdAsync(query.AccountId);

            if (bankAccount == null)
            {
                //throw new NotFoundException(nameof(BankAccount), query.AccountId);
            }

            return bankAccount;
        }

    }
}
