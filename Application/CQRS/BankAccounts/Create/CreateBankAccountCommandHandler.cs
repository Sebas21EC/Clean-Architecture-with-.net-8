using Domain.Entities.BankAccounts;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.BankAccounts.Create
{
    internal sealed class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, ErrorOr<Unit>>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository, IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<ErrorOr<Unit>> Handle(CreateBankAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
                {
                    return Error.Validation("BankAccounts.PhonNumbre", "Invalid phone number");
                }

                var bankAccount = new BankAccount(
                    new BankAccountId(Guid.NewGuid()),
                    command.Number,
                    command.BankName,
                    command.Name,
                    command.Details,
                    true,
                    phoneNumber

                );

                await _bankAccountRepository.Add(bankAccount);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure("BankAccounts.Failure",ex.Message);
            }

        }


    }

}
