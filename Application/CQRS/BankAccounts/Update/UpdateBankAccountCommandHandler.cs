using Domain.Entities.BankAccounts;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.BankAccounts.Update
{
    internal sealed class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, ErrorOr<Unit>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateBankAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Recuperar la cuenta bancaria a actualizar
                var bankAccount = await _bankAccountRepository.GetByIdAsync(command.AccountId);

                if (bankAccount == null)
                {
                    return Error.NotFound("BankAccounts.NotFound", $"Bank account with ID {command.AccountId} not found.");
                }

                // Actualizar los campos de la cuenta bancaria
                bankAccount.Update(
                    command.Number,
                    command.BankName,
                    command.Name,
                    command.Details,
                    command.Status,
                    PhoneNumber.Create(command.PhoneNumber)
                );

                // Guardar cambios en el contexto
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure("BankAccounts.Failure", ex.Message);
            }
        }
    }
}
