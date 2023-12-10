using ErrorOr;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.BankAccounts;
using Domain.Primitives;

namespace Application.CQRS.BankAccounts.Delete
{
    internal sealed class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, ErrorOr<Unit>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankAccountCommandHandler(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteBankAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Recuperar la cuenta bancaria a eliminar (puedes ajustar esto según tu lógica)

                var bankAccount = await _bankAccountRepository.GetByIdAsync(command.AccountId);

                if (bankAccount == null)
                {
                    return Error.NotFound("BankAccounts.NotFound", $"Bank account with ID {command.AccountId} not found.");
                }

                // Realizar la lógica de eliminación
                _bankAccountRepository.Remove(bankAccount);

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
